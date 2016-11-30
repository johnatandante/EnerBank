using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using EnerBank.Interfaces;
using EnerBank.IOUtils;
using EnerBank.Model.Services;

namespace EnerBank.UI.Web.DotNet45.Controllers
{
	public class EvaluateController : ApiController
	{
	
		IWorkSessionRepository repository;

		[HttpGet]
		public IEnumerable<IWorkSession> Get() {
			repository = WorkSessionRepository.GetRepo();
			return WorkSessionRepository.GetRepo().GetAll();

		}

		[HttpGet]
		public string Get(string id) {
			repository = WorkSessionRepository.GetRepo();

			IWorkSession item;
			repository.TryGetById(id, out item);
			if (!repository.TryGetById(id, out item))
				throw new HttpResponseException(HttpStatusCode.NotFound);

			return File.ReadAllText(item.ResultFileName);
		}

		[HttpPost]
		public async Task<HttpResponseMessage> Post() {

			FileInfo source = null;
			FileInfo filter = null;

			repository = WorkSessionRepository.GetRepo();

			FileInfo[] fileInfos = await ReadFileStream();

			if (fileInfos.Length == 0)
				return new HttpResponseMessage(HttpStatusCode.NoContent);

			source = fileInfos[0];

			if (fileInfos.Length == 1)
				return new HttpResponseMessage(HttpStatusCode.NoContent);

			filter = fileInfos[1];

			ISessionWorker sessionWorker = SessionWorker.GetNew(source.FullName, filter.FullName);
			IWorkSession result = repository.InsertNew(sessionWorker.GetResult());

			FileInfo resultFileInfo = new FileInfo(result.ResultFileName);

			List<string[]> content = Consume(resultFileInfo);

			return  new HttpResponseMessage(HttpStatusCode.Created) {
				Content = new StringContent(new JavaScriptSerializer().Serialize(content.ToArray()), Encoding.UTF8, "application/json")				 
			};

		}

		private static List<string[]> Consume(FileInfo resultFileInfo) {
			List<string[]> content = new List<string[]>();
			foreach (string record in Reader.Read(resultFileInfo.FullName)) {
				content.Add(Reader.Tokenize(record));
			}

			try {
				File.Delete(resultFileInfo.FullName);
			} catch {
				// pass
			}
			return content;
		}

		private async Task<FileInfo[]> ReadFileStream() {
			List<FileInfo> filesUploaded = new List<FileInfo>();

			// Check if the request contains multipart/form-data.
			if (!Request.Content.IsMimeMultipartContent()) {
				throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
			}

			string root = HttpContext.Current.Server.MapPath("~/App_Data");
			var provider = new MultipartFormDataStreamProvider(root);

			try {
				// Read the form data and return an async task.
				await Request.Content.ReadAsMultipartAsync(provider);

				foreach (var file in provider.FileData) {
					FileInfo fileInfo = new FileInfo(file.LocalFileName);
					filesUploaded.Add(fileInfo);
				}
				
			} catch (System.Exception) {
				// catch
			}

			return filesUploaded.ToArray();
		}

	}
}