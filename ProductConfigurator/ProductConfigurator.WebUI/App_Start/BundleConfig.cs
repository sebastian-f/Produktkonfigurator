using System.Web;
using System.Web.Optimization;

namespace ProductConfigurator.WebUI
{
	public class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                        "~/Script/JavaScript1.js",
                        "~/Script/datepickr.js"));

            bundles.Add(new ScriptBundle("~/bundles/user").Include(
                        "~/Script/UserScript.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/bootstrap/css/bootstrap*",
                "~/Style/StyleSheet1.css"));

        }	
	}
}