﻿using System;
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
            ViewBag.Usuario = Response.Cookies["displayName"].Value ?? Session["displayName"];
            return View();
        }
    }
}