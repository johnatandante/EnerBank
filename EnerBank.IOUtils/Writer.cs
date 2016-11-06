using System.IO;

namespace EnerBank.IOUtils
{
	public class Writer
	{

		public static string Write(object[] collection, string fileName) {
			using (var writer = new StreamWriter(System.IO.File.Create(fileName)) ){
				writer.AutoFlush = true;
				foreach (var item in collection)
					writer.WriteLine(item.ToString());

			}

			return fileName;
				 
		}

	}
}
