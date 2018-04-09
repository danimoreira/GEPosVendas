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
            bundles.Add(new StyleBundle("~/BundleStyles/styles").Include(
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
                        "~/Content/_Layout.css"));

            bundles.Add(new ScriptBundle("~/bundles/layout/script").Include(
                        "~/Scripts/modernizr-*",
                        "~/Scripts/jquery-3.0.0.js",
                        "~/Scripts/bootstrap.bundle.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap-select.js",
                        "~/Scripts/bootstrap-datepicker.js",
                        "~/Scripts/toastr.js",
                        "~/Scripts/popper-utils.js",
                        "~/Scripts/popper.js",
                        "~/Scripts/Tarefas.js"));            
        }
    }
}