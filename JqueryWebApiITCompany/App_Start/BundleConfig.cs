using System.Web;
using System.Web.Optimization;

namespace JqueryWebApiITCompany
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/DataTables/dataTables.bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/bundles/libJquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        //"~/Scripts/bootstrap.js",
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/jquery.validate.min.js",
                        //"~/Scripts/DataTables/dataTables.bootstrap.js",
                        "~/Scripts/respond.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
