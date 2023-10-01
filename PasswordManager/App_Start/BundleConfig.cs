using System.Web;
using System.Web.Optimization;

namespace PasswordManager
{
    public class BundleConfig
    {
        // Paketleme hakkında daha fazla bilgi için lütfen https://go.microsoft.com/fwlink/?LinkId=301862 adresini ziyaret edin.
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Geliştirme yapmak ve öğrenme kaynağı olarak yararlanmak için Modernizr uygulamasının geliştirme sürümünü kullanın. Ardından
            // üretim için hazır. https://modernizr.com adresinde derleme aracını kullanarak yalnızca ihtiyacınız olan testleri seçin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new Bundle("~/bundles/login").Include(
                     "~/Scripts/login.js"));

            bundles.Add(new Bundle("~/bundles/popper").Include(
                    "~/Scripts/popper.min.js"));

            bundles.Add(new Bundle("~/bundles/main").Include(
                   "~/Scripts/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/login.css",
                      "~/Content/bootstrap.css",
                      "~/Content/owl.carousel.min.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/dashboard").Include(
                     "~/Content/dashboard/css/fonts.googleapis.com_css_family=Roboto_.css",
                     "~/Content/dashboard/css/bootstrap.min.css",
                     "~/Content/dashboard/css/font-awesome.min.css",
                     "~/Content/dashboard/css/owl.carousel.css",
                     "~/Content/dashboard/css/owl.theme.css",
                     "~/Content/dashboard/css/owl.transitions.css",
                     "~/Content/dashboard/css/animate.css",
                     "~/Content/dashboard/css/normalize.css",
                     "~/Content/dashboard/css/meanmenu.min.css",
                     "~/Content/dashboard/css/main.css",
                     "~/Content/dashboard/css/educate-custon-icon.css",
                     "~/Content/dashboard/css/morrisjs/morris.css",
                     "~/Content/dashboard/css/scrollbar/jquery.mCustomScrollbar.min.css",
                     "~/Content/dashboard/css/metisMenu/metisMenu.min.css",
                     "~/Content/dashboard/css/metisMenu/metisMenu-vertical.css",
                     "~/Content/dashboard/css/calendar/fullcalendar.min.css",
                     "~/Content/dashboard/css/calendar/fullcalendar.print.min.css",
                     "~/Content/dashboard/css/style.css",
                     "~/Content/dashboard/css/responsive.css",
                     "~/Content/dashboard/css/cdn.datatables.net_1.13.6_css_jquery.dataTables.min.css",
                     "~/Content/font-awesome/css/font-awesome.min.css",
                     "~/Content/dashboard/css/ajax.aspnetcdn.com_ajax_jquery.ui_1.8.14_themes_black-tie_jquery-ui.css"));

            bundles.Add(new Bundle("~/bundles/dashboard").Include(
                  "~/Content/dashboard/js/vendor/jquery-1.12.4.min.js",
                   "~/Content/dashboard/js/bootstrap.min.js",
                   "~/Content/dashboard/js/wow.min.js",
                   "~/Content/dashboard/js/jquery-price-slider.js",
                   "~/Content/dashboard/js/jquery.meanmenu.js",
                    "~/Content/dashboard/js/owl.carousel.min.js",
                    "~/Content/dashboard/js/jquery.sticky.js",
                     "~/Content/dashboard/js/jquery.scrollUp.min.js",
                      "~/Content/dashboard/js/counterup/jquery.counterup.min.js",
                      "~/Content/dashboard/js/counterup/waypoints.min.js",
                      "~/Content/dashboard/js/counterup/counterup-active.js",
                      "~/Content/dashboard/js/scrollbar/jquery.mCustomScrollbar.concat.min.js",
                      "~/Content/dashboard/js/scrollbar/mCustomScrollbar-active.js",
                      "~/Content/dashboard/js/metisMenu/metisMenu.min.js",
                      "~/Content/dashboard/js/metisMenu/metisMenu-active.js",
                      "~/Content/dashboard/js/sparkline/jquery.sparkline.min.js",
                      "~/Content/dashboard/js/sparkline/jquery.charts-sparkline.js",
                      "~/Content/dashboard/js/sparkline/sparkline-active.js",
                      "~/Content/dashboard/js/calendar/moment.min.js",
                      "~/Content/dashboard/js/calendar/fullcalendar.min.js",
                      "~/Content/dashboard/js/calendar/fullcalendar-active.js",
                      "~/Content/dashboard/js/plugins.js",
                      "~/Content/dashboard/js/main.js"));
        }
    }
}
