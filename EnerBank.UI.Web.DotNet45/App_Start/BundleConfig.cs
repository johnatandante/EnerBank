using System.Web;
using System.Web.Optimization;

namespace EnerBank.UI.Web.DotNet45
{
	public class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles) {
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
						"~/Scripts/bootstrap/js/bootstrap-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/angular").Include(
						"~/Scripts/angular/angular.js"
						, "~/Scripts/angular/angular-resource.js"
						, "~/Scripts/angular/angular-route.js"
			));

			bundles.Add(new ScriptBundle("~/bundles/app").Include(
						"~/JsApp/common/utils.js",
						"~/JsApp/services/localDataService.js",
						"~/JsApp/controllers/mainControllers.js",
						"~/JsApp/mainApp.js"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrapui").Include(
						 "~/Scripts/ui-bootstrap-tpls-{version}.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
				"~/Content/index.css"));

			bundles.Add(new StyleBundle("~/Content/theme").Include(
					"~/Scripts/bootstrap/css/bootstrap.css"
					,"~/Scripts/bootstrap/css/bootstrap-theme.css"));

		}
	}
}