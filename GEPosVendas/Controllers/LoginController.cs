using GEPV.Domain.DTO;
using GEPV.Domain.Interfaces.Services;
using GEPV.Domain.Repository;
using GEPV.Domain.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GEPosVendas.Controllers
{
    public class LoginController : Controller
    {
        //[Inject]
        //public ILoginService Service { get; set; }

        private LoginService Service = new LoginService(new LoginRepository());

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginDto loginDto)
        {
            var usuarioDados = Service.Logar(loginDto);

            if (usuarioDados == null)
                return View("Index", loginDto);

            Session["userId"] = usuarioDados.Id;
            Session["userName"] = usuarioDados.Login;
            
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return View("Index", new LoginDto());
        }
    }
}