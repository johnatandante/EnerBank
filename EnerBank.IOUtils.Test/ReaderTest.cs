using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnerBank.IOUtils.Test
{
	[TestClass]
	public class ReaderTest
	{

		string fileThatExists; 
		string fileThatNotExists;

		string[] emptyFileContent =  new string[] { string.Empty };
		string csvRecordWith7Items = "ciao,ciao,ciao,mare,100,200,A";
		string csvRecordWithDoubleQuotesWith6Items = "\"ciao,ciao\",ciao,mare,100,200,A";
		
		[TestInitialize]
		public void InitTest() {
			fileThatExists = Path.GetTempFileName();
			File.WriteAllLines(fileThatExists, emptyFileContent);

			fileThatNotExists = Path.GetTempFileName();
			
		}

		[TestMethod]
		public void FromAGivenFileNameThatExists_ThenLinesReadMustBeGreaterThan1() {
			
			Assert.IsTrue(Reader.Read(fileThatExists).LongLength >= 1);

		}

		[TestMethod]
		public void FromAGivenFileNameThatNotExists_ThenLinesReadMustBeGreaterThan1() {

			Assert.IsFalse(Reader.Read(fileThatNotExists).LongLength >= 1);

		}

		[TestMethod]
		public void FromAGivenCsvString_TokenizeMustReturnNonEmptyArray() {

			Assert.IsTrue(Reader.Tokenize(csvRecordWith7Items).Length ==7);
			Assert.IsTrue(Reader.Tokenize(csvRecordWithDoubleQuotesWith6Items).Length == 6);

		}


		[TestCleanup]
		public void Cleanups() {
			File.Delete(fileThatExists);

		}

	}
}
