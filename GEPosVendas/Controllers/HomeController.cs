using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GEPosVendas.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {   
            ViewBag.Usuario = HttpContext.Request.Cookies["displayName"].Value;
            if (string.IsNullOrEmpty(ViewBag.Usuario))
                return RedirectToAction("Index", "Login");

            return RedirectToAction("Index", "Tarefas");
        }
    }
}