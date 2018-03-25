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
            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap-grid.css",
                        "~/Content/bootstrap-reboot.css",
                        "~/Content/DataTables/css/dataTables.jqueryui.min.css",
                        "~/Content/bootstrap-select.css",
                        "~/Content/font-awesome.min.css",
                        "~/Content/toastr.css",
                        "~/Content/stater-template.css",
                        "~/Content/signin.css",
                        "~/Content/style.css",
                        "~/Content/bootstrap-datepicker.css",
                        "~/Content/bootstrap-datepicker3.css",
                        "~/Content/_Layout.css"));

            bundles.Add(new ScriptBundle("~/bundles/layout/js").Include(
                        "~/Scripts/modernizr-*",
                        "~/Scripts/jquery-3.0.0.js",
                        "~/Scripts/bootstrap.bundle.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap-dialog.js",
                        "~/Scripts/bootstrap-select.js",
                        "~/Scripts/bootstrap-datepicker.js",
                        "~/Scripts/toastr.js",
                        "~/Scripts/popper-utils.js",
                        "~/Scripts/popper.js",                        
                        "~/Scripts/Views/Tarefas.js"));            
        }
    }
}