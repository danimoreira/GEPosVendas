using GEPV.Domain.Entities;
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
        private ContatosService Service = new ContatosService(new ContatosRepository());

        // GET: Tarefas
        public ActionResult Index()
        {
            Consultas consultaSQL = new Consultas();

            ViewBag.Vendedores = consultaSQL.GetVendedores();
            ViewBag.FornecedorPorCliente = consultaSQL.GetFornecedoresPorCliente();
            ViewBag.Clientes = consultaSQL.GetClientes();

            return View();
        }
        
        public ActionResult RealizarTarefas(int? idCliente, int? idFornecedor)
        {
            if (!idCliente.HasValue)
                return RedirectToAction("Index");

            ViewBag.Historico = new Consultas().GetHistoricoContatos(idCliente, null);
            ViewBag.IdCliente = idCliente;
            ViewBag.IdVendedor = 2;
            ViewBag.IdFornecedor = idFornecedor;

            return View();
        }

        [HttpPost]
        public ActionResult Salvar(Contatos contato)
        {
            if (ModelState.IsValid)
            {
                Service.Add(contato);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


    }
}