using System.IO;

namespace EnerBank.IOUtils
{
	public class Writer
	{
		const string DefaultFileName = "result.csv";

		public static string Write(object[] collection, string fileName = DefaultFileName) {
			using (StreamWriter writer = new StreamWriter(fileName)) {
				writer.AutoFlush = true;
				foreach (var item in collection)
					writer.WriteLine(item.ToString());

			}

			return fileName;
				 
		}

	}
}
