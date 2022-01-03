using System.Web.Optimization;

namespace PRUEBAGILA
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {

            // CSS style 
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/assets/vendors/global/vendors.bundle.css",
                      "~/Content/assets/css/demo1/style.bundle.css",
                      "~/Content/assets/css/demo1/skins/header/base/light.css",
                      "~/Content/assets/css/demo1/skins/header/menu/light.css",
                      "~/Content/assets/css/demo1/skins/brand/navy.css",
                      "~/Content/assets/css/demo1/skins/aside/navy.css",
                      "~/Scripts/DataTables/datatables.min.css",
                      "~/Content/assets/css/demo1/pages/wizards/wizard-v1.css"));

            bundles.Add(new StyleBundle("~/Calendar/css").Include("~/Content/assets/vendors/custom/fullcalendar/fullcalendar.bundle.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Wizard3/css").Include("~/Content/assets/css/demo1/pages/wizards/wizard-v3.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/Wizard1/css").Include("~/Content/assets/css/demo1/pages/wizards/wizard-v1.css", new CssRewriteUrlTransform()));

            // Js
            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                        "~/Content/assets/vendors/global/vendors.bundle.js",
                        "~/Content/assets/js/demo1/scripts.bundle.js",
                        "~/Scripts/jquery.numeric.js"));

            bundles.Add(new ScriptBundle("~/FullCalendar/js").Include(
                        "~/public/assets/plugins/custom/fullcalendar/fullcalendar.bundle.js",
                        "~/public/assets/plugins/custom/fullcalendar/locales-all.js"));
                  //,"~/assets/vendors/custom/fullcalendar/fullcalendar.bundle.js"

                  bundles.Add(new ScriptBundle("~/Datatables/js").Include(
                "~/Content/assets/vendors/custom/datatables/datatables.bundle.js"));

            bundles.Add(new ScriptBundle("~/Invoice2/css").Include(
                "~/public/assets/css/pages/invoice/invoice-v2.css", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/Invoice3/css").Include(
               "~/public/assets/css/pages/invoice/invoice-v3.css", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/Datatabless/js").Include(
                "~/Scripts/datatable.js",
                "~/Scripts/datatableLanguage.js"));

            bundles.Add(new ScriptBundle("~/DatatablesEs/js").Include(
                "~/Scripts/jquery.dataTables.min.js",
                "~/Scripts/datatableLanguage2.js"));

            bundles.Add(new StyleBundle("~/Datatable/css").Include(
                     "~/Scripts/DataTables/datatables.min.css"));

            bundles.Add(new ScriptBundle("~/DatatableResponsice/js").Include(
                    "~/Content/assets/js/demo1/pages/components/datatables/extensions/responsive.js"));

            bundles.Add(new ScriptBundle("~/BootstrapDatepicker/js").Include(
                    "~/Content/assets/js/demo1/pages/components/forms/widgets/bootstrap-datepicker.js"));

            bundles.Add(new ScriptBundle("~/BootstrapDatetimepicker/js").Include(
                    "~/Content/assets/js/demo1/pages/components/forms/widgets/bootstrap-datetimepicker.js"));

            bundles.Add(new ScriptBundle("~/BootstrapSelect/js").Include(
                "~/public/assets/js/pages/components/forms/widgets/bootstrap-select.js"));

            bundles.Add(new ScriptBundle("~/FomatosES/js").Include(
                    "~/Scripts/formatEs.js"));

            bundles.Add(new ScriptBundle("~/Wizard1/js").Include(
                "~/Scripts/wizard-v1.js"));

        }
    }
}
