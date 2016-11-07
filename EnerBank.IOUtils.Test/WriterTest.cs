using System.IO;
using Xunit;

namespace EnerBank.IOUtils.Test
{
	/// <summary>
	/// Summary description for Writer
	/// </summary>
	public class WriterTest
	{
		static object[] nonEmptyCollection = new object[] { 1 };
		static object[] emptyCollection = new object[] {  };		
		static object[] csvCollection = (object[])DataUtils.CsvMocked.Clone();

		static string fileNameNonEmptyCollection = "fileNameNonEmptyCollection.csv";
		static string fileNameemptyCollection = "fileNameemptyCollection.csv";
		static string fileNamecsvCollection = "fileNamecsvCollection.csv";
		
		[Fact]
		public void FromANonEmptyCollection_FileResultMustBeNonEmpty() {
			string file = Writer.Write(nonEmptyCollection, fileNameNonEmptyCollection);
			Assert.Equal(file, fileNameNonEmptyCollection);
			Assert.True(File.Exists(fileNameNonEmptyCollection));
			Assert.True(new FileInfo(fileNameNonEmptyCollection).Length > 0);
		}

		public void FromAnEmptyCollection_FileResultMustBeEmpty() {
			string file = Writer.Write(emptyCollection, fileNameemptyCollection);
			Assert.Equal(file, fileNameemptyCollection);
			Assert.True(File.Exists(fileNameemptyCollection));
			Assert.True(new FileInfo(fileNameemptyCollection).Length == 0);
		}

		public void FromAnCsvRecordCollection_FileResultMustBeEmpty() {
			string file = Writer.Write(csvCollection, fileNamecsvCollection);
			Assert.Equal(file, fileNamecsvCollection);
			Assert.True(File.Exists(fileNamecsvCollection));
			Assert.True(new FileInfo(fileNamecsvCollection).Length > 0); 
		}

		#region Additional test attributes

		public  WriterTest() { }

		~WriterTest() {
			Cleanup(fileNameNonEmptyCollection);
			Cleanup(fileNameemptyCollection);
			Cleanup(fileNamecsvCollection);

		}

		private void Cleanup(string file) {
			if (File.Exists(file))
				File.Delete(file);
		}

		#endregion

		
	}
}
