using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace EnerBank.IOUtils.Test
{
	/// <summary>
	/// Summary description for Writer
	/// </summary>
	[TestClass]
	public class WriterTest
	{
		static object[] nonEmptyCollection = new object[] { 1 };
		static object[] emptyCollection = new object[] {  };		
		static object[] csvCollection = (object[])DataUtils.CsvMocked.Clone();

		static string fileNameNonEmptyCollection = "fileNameNonEmptyCollection.csv";
		static string fileNameemptyCollection = "fileNameemptyCollection.csv";
		static string fileNamecsvCollection = "fileNamecsvCollection.csv";
		
		[TestMethod]
		public void FromANonEmptyCollection_FileResultMustBeNonEmpty() {
			string file = Writer.Write(nonEmptyCollection, fileNameNonEmptyCollection);
			Assert.AreEqual(file, fileNameNonEmptyCollection);
			Assert.IsTrue(File.Exists(fileNameNonEmptyCollection));
			Assert.IsTrue(new FileInfo(fileNameNonEmptyCollection).Length > 0);
		}

		public void FromAnEmptyCollection_FileResultMustBeEmpty() {
			string file = Writer.Write(emptyCollection, fileNameemptyCollection);
			Assert.AreEqual(file, fileNameemptyCollection);
			Assert.IsTrue(File.Exists(fileNameemptyCollection));
			Assert.IsTrue(new FileInfo(fileNameemptyCollection).Length == 0);
		}

		public void FromAnCsvRecordCollection_FileResultMustBeEmpty() {
			string file = Writer.Write(csvCollection, fileNamecsvCollection);
			Assert.AreEqual(file, fileNamecsvCollection);
			Assert.IsTrue(File.Exists(fileNamecsvCollection));
			Assert.IsTrue(new FileInfo(fileNamecsvCollection).Length > 0); 
		}

		#region Additional test attributes

		[TestInitialize]
		public void Initialize() { }

		[TestCleanup]
		public void Cleanup() {
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
