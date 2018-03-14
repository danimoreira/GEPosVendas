using GEPV.Domain.Interfaces.Services;
using GEPV.Domain.Repository;
using GEPV.Domain.Services;
using GEPV.Domain.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GEPosVendas.Controllers
{
    public class TarefasController : Controller
    {
        // GET: Tarefas
        public ActionResult Index()
        {
            Consultas consultaSQL = new Consultas();

            ViewBag.Vendedores = consultaSQL.GetVendedores();
            ViewBag.FornecedorPorCliente = consultaSQL.GetFornecedoresPorCliente();
            ViewBag.Clientes = consultaSQL.GetClientes();

            return View();
        }
    }
}