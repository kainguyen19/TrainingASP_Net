using System.Web;
using System.Web.Optimization;

namespace Lab3
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Bundle/css").Include(
                    "~/Content/css/font_Muli.css",
                    "~/Content/css/bootstrap.min.css",
                    "~/Content/css/font-awesome.min.css",
                    "~/Content/css/themify-icons.css",
                    "~/Content/css/elegant-icons.css",
                    "~/Content/css/owl.carousel.min.css",
                    "~/Content/css/nice-select.css",
                    "~/Content/css/jquery-ui.min.css",
                    "~/Content/css/slicknav.min.css",
                    "~/Content/css/style.css"
                ));

            bundles.Add(new ScriptBundle("~/Bundle/js").Include(
                    "~/Content/js/jquery-3.3.1.min.js",
                    "~/Content/js/bootstrap.min.js",
                    "~/Content/js/jquery-ui.min.js",
                    "~/Content/js/jquery.countdown.min.js",
                    "~/Content/js/jquery.nice-select.min.js",
                    "~/Content/js/jquery.zoom.min.js",
                    "~/Content/js/jquery.dd.min.js",
                    "~/Content/js/jquery.slicknav.js",
                    "~/Content/js/owl.carousel.min.js",
                    "~/Content/js/main.js"
                ));
        }

    }
}
