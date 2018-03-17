using GEPV.Domain.DTO;
using GEPV.Domain.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GEPosVendas.Controllers
{
    public class HistoricoController : Controller
    {
        // GET: Historico
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult Pesquisar(int? idCliente, int? idVendedor)
        {
            ViewBag.Historico = new Consultas().GetHistoricoContatos(idCliente, idVendedor);
            return View("Index");
        }
    }
}