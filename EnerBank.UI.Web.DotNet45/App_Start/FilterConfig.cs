using System.Web;
using System.Web.Mvc;

namespace EnerBank.UI.Web.DotNet45
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
			filters.Add(new HandleErrorAttribute());
		}
	}
}