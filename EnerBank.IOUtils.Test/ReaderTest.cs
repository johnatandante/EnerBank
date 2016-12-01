using System.IO;
using Xunit;

namespace EnerBank.IOUtils.Test
{
	public class ReaderTest
	{

		string fileThatExists; 
		string fileThatNotExists;

		string[] emptyFileContent =  new string[] { string.Empty };
		string csvRecordWith7Items = "ciao,ciao,ciao,mare,100,200,A";
		string csvRecordWithDoubleQuotesWith6Items = "\"ciao,ciao\",ciao,mare,100,200,A";
		
		public ReaderTest() {
			fileThatExists = Path.GetTempFileName();
			File.WriteAllLines(fileThatExists, emptyFileContent);

			fileThatNotExists = Path.GetTempFileName();
			
		}

		[Fact]
		public void FromAGivenFileNameThatExists_ThenLinesReadMustBeGreaterThan1() {
			
			Assert.True(Reader.Read(fileThatExists).Length >= 1);

		}

		[Fact]
		public void FromAGivenFileNameThatNotExists_ThenLinesReadMustBeGreaterThan1() {

			Assert.True(Reader.Read(fileThatNotExists).Length >= 1);

		}

		[Fact]
		public void FromAGivenCsvString_TokenizeMustReturnNonEmptyArray() {

			Assert.True(Reader.Tokenize(csvRecordWith7Items).Length ==7);
			Assert.True(Reader.Tokenize(csvRecordWithDoubleQuotesWith6Items).Length == 6);

		}

		~ReaderTest() {
			File.Delete(fileThatExists);

		}

	}
}
