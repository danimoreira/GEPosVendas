using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace GEPosVendas
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/BundleStyles/cssfiles").Include(
                        "~/Content/bootstrap.min.css",
                        "~/Content/bootstrap-grid.min.css",
                        "~/Content/bootstrap-reboot.min.css",
                        "~/Content/DataTables/css/dataTables.jqueryui.min.css",
                        "~/Content/bootstrap-select.min.css",
                        "~/Content/font-awesome.min.css",
                        "~/Content/toastr.min.css",
                        "~/Content/stater-template.css",
                        "~/Content/signin.css",
                        "~/Content/style.css",
                        "~/Content/bootstrap-datepicker.min.css",
                        "~/Content/bootstrap-datepicker.standalone.min.css",
                        "~/Content/bootstrap-datepicker3.min.css",
                        "~/Content/alertify/alertify.core.css",
                        "~/Content/alertify/alertify.default.css",
                        "~/Content/_Layout.css"));

            bundles.Add(new ScriptBundle("~/bundles/jsfiles").Include(
                        "~/Scripts/jquery-3.0.0.min.js",
                        "~/Scripts/bootstrap.bundle.min.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/bootstrap-select.min.js",
                        "~/Scripts/bootstrap-datepicker.min.js",
                        "~/Scripts/Tarefas.js"));            
        }
    }
}