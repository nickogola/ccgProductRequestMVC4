using System.Web;
using System.Web.Optimization;

namespace ccgMVCApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                "~/Scripts/jquery.js",
                "~/Scripts/jquery-1.4.3.min.js",
                "~/Scripts/jquery_002.js",
                "~/Scripts/jquery_003.js",
                "~/Scripts/smoothscroll.js"));

            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
               "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
               "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
               "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
               "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            bundles.Add(new ScriptBundle("~/bundles/fancybox").Include(
               "~/fancybox/jquery.easing-1.3.pack.js",
               "~/fancybox/jquery.fancybox-1.3.4.js",
               "~/fancybox/jquery.fancybox-1.3.4.pack.js",
               "~/fancybox/jquery.mousewheel-3.0.4.pack.js"));
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/style.css",
                     "~/Content/bootstrap.css", 
                     "~/fancybox/jquery.fancybox-1.3.4.css"));
                     // "~/Content/bootstrap.css",
                     // "~/Content/site.css"));
        }
    }
}
