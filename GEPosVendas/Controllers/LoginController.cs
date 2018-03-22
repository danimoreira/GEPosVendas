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
using System.Web.Security;

namespace GEPosVendas.Controllers
{
    public class LoginController : Controller
    {
        

        private LoginService Service = new LoginService(new LoginRepository());

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginDto loginDto, string returnUrl)
        {
            var usuarioDados = Service.Logar(loginDto);

            if (usuarioDados == null)
                return View("Index", loginDto);

            FormsAuthentication.SetAuthCookie(loginDto.Usuario, false);

            Response.Cookies.Remove("displayName");
            HttpCookie cookie = new HttpCookie("displayName", usuarioDados.Nome);
            Response.Cookies.Add(cookie);

            Response.Cookies.Remove("emailUsuario");
            HttpCookie cookieEmailUsuario = new HttpCookie("emailUsuario", usuarioDados.Email);
            Response.Cookies.Add(cookieEmailUsuario);
            
            returnUrl = returnUrl ?? "/";

            return Redirect(returnUrl);
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return View("Index", new LoginDto());
        }
    }
}