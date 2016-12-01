using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EnerBank.Interfaces;
using EnerBank.IOUtils;
using EnerBank.Model.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace EnerBank.Web.Controllers
{
	public class EvaluateController : Controller
	{
	
		IWorkSessionRepository repository;

		private IHostingEnvironment _environment;

		public EvaluateController(IHostingEnvironment environment) {
			_environment = environment;
		}

		[HttpGet]
		public IEnumerable<IWorkSession> Get() {
			repository = WorkSessionRepository.GetRepo();
			return WorkSessionRepository.GetRepo().GetAll();

		}

		[HttpGet]
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

				ISessionWorker sessionWorker = SessionWorker.GetNew(source.FullName, filter.FullName);
				IWorkSession result = repository.InsertNew(sessionWorker.GetResult());

				FileInfo resultFileInfo = new FileInfo(result.ResultFileName);

				List<string[]> content = Consume(resultFileInfo);

				return new OkObjectResult(content.ToArray());
			} catch (HttpRequestException) {
				return new NoContentResult();
			}
		}

		private static List<string[]> Consume(FileInfo resultFileInfo) {
			List<string[]> content = new List<string[]>();
			foreach (string record in Reader.Read(resultFileInfo.FullName)) {
				content.Add(Reader.Tokenize(record));
			}

			try {
				System.IO.File.Delete(resultFileInfo.FullName);
			} catch {
				// pass
			}
			return content;
		}

		private async Task<FileInfo[]> ReadFileStream() {
			List<FileInfo> filesUploaded = new List<FileInfo>();

			// Check if the request contains multipart/form-data.
			//if (!Request.Content.IsMimeMultipartContent()) {
			if (!HttpContext.Request.HasFormContentType) {
				throw new HttpRequestException("Unsupported Media Type");
			}

			string uploads  = Path.Combine(_environment.WebRootPath, "uploads");
			
			try {
				// Read the form data and return an async task.
				IFormCollection collection = await Request.ReadFormAsync();
				foreach(var item in collection) {
					System.Console.WriteLine("Item: " + item.Key);
					//ICollection<IFormFile> files = item.Value as ICollection<IFormFile>;
					//foreach (var file in files) {
						//if (file.Length > 0) {
						//	using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create)) {
						//		await file.CopyToAsync(fileStream);
						//	}
						//}
					//	FileInfo fileInfo = new FileInfo(file.LocalFileName);
					//	filesUploaded.Add(fileInfo);
					//}

				}
				
			} catch (System.Exception) {
				// catch
			}

			return filesUploaded.ToArray();
		}

	}
}