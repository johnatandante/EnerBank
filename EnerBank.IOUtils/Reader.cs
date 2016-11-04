using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace EnerBank.IOUtils
{

	/// <summary>
	/// Come input due file CSV con formato come definito nella RFC4180, sezione 2, senza header.
	/// https://tools.ietf.org/html/rfc4180#section-2</remarks>
	/// </summary>
    public class Reader
    {
		
		// string dateFormat = "YYYY-MM-DDThh:mm:ssTZD";

		static string[] Empty = new string[] { };

		/// <summary>
		/// Thanks to http://geekswithblogs.net/mwatson/archive/2004/09/04/10658.aspx
		/// </summary>
		static string regex = "(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)";

		public static string[] Read(string filename) {
			if (!File.Exists(filename))
				return Empty;

			return File.ReadAllLines(filename);
		}

		public static string[] Tokenize(string record) {
			if (string.IsNullOrWhiteSpace(record))
				return Empty;

			return Regex.Split(record, regex)
				.Where(s => !string.IsNullOrWhiteSpace(s))
				.ToArray();
		}

	}
	
}
