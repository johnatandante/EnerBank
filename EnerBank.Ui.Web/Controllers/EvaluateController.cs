using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using EnerBank.Interfaces;
using EnerBank.IOUtils;
using EnerBank.Model.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnerBank.Web.Controllers
{
	[Route("api/evaluate")]
	public class EvaluateController : Controller
	{
		// ref
		// http://blog.scottlogic.com/2016/01/20/restful-api-with-aspnet50.html

		const string UploadsDir = "uploads";

		IWorkSessionRepository repository;
		string uploads;

		private IHostingEnvironment _environment;

		public EvaluateController(IHostingEnvironment environment) {
			_environment = environment;
			
			uploads  = Path.Combine(_environment.WebRootPath, UploadsDir);
			if (!Directory.Exists(uploads)) {
				Directory.CreateDirectory(uploads);
			}

		}

		[HttpGet]
		public IEnumerable<IWorkSession> Get() {
			repository = WorkSessionRepository.GetRepo();
			return WorkSessionRepository.GetRepo().GetAll();

		}

		[HttpGet("{id}")]
		public IActionResult Get(string id) {
			repository = WorkSessionRepository.GetRepo();

			IWorkSession item;
			repository.TryGetById(id, out item);
			if (!repository.TryGetById(id, out item))
				return new NotFoundResult();

			return new OkObjectResult(System.IO.File.ReadAllText(item.ResultFileName));
		}

		[HttpPost]
		public async Task<IActionResult> Post() {

			FileInfo source = null;
			FileInfo filter = null;

			repository = WorkSessionRepository.GetRepo();

			try {
				FileInfo[] fileInfos = await ReadFileStream();

				if (fileInfos.Length == 0)
					return new NoContentResult();

				source = fileInfos[0];

				if (fileInfos.Length == 1)
					return new NoContentResult();

				filter = fileInfos[1];

				ModelFactory environment = SessionWorker.GetNewEnvironment();
				IWorkSession sessionResult = environment
										.GetNew<ISessionWorker>(environment)
										.Run(source.FullName, filter.FullName)
										.GetResult();
				
				IWorkSession result = repository.InsertNew(sessionResult);

				FileInfo resultFileInfo = new FileInfo(result.ResultFileName);

				List<string[]> content = Consume(resultFileInfo);
				CleanUploads(fileInfos);

				return new OkObjectResult(content.ToArray());
			} catch (HttpRequestException) {
				return new NoContentResult();
			}
		}

		private void CleanUploads(FileInfo[] fileInfos) {
			foreach (FileInfo file in fileInfos) {
				try {
					file.Delete();
				} catch {
					// pass
				}
			}

		}

		private static List<string[]> Consume(FileInfo resultFileInfo) {
			List<string[]> content = new List<string[]>();
			foreach (string record in Reader.Read(resultFileInfo.FullName)) {
				content.Add(Reader.Tokenize(record));
			}

			try {
				resultFileInfo.Delete();
			} catch {
				// pass
			}
			return content;
		}

		private async Task<FileInfo[]> ReadFileStream() {
			List<FileInfo> filesUploaded = new List<FileInfo>();

			// Check if the request contains multipart/form-data.
			if (!HttpContext.Request.HasFormContentType) {
				throw new HttpRequestException("Unsupported Media Type");
			}
			
			try {
				// Read the form data and return an async task.
				foreach (var file in Request.Form.Files) {
					if (file.Length <= 0)
						continue;

					FileInfo toUpload = new FileInfo(file.FileName);
					string fileName = Path.Combine(uploads, toUpload.Name);
					using (Stream fileStream = new FileStream(fileName, FileMode.Create)) {
						await file.CopyToAsync(fileStream);						
					}
					
					filesUploaded.Add(new FileInfo(fileName));

				}
			} catch (System.Exception) {
				// catch
			}

			return filesUploaded.ToArray();
		}

	}
}