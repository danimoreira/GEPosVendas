using GEPV.Domain.DTO;
using GEPV.Domain.Entities;
using GEPV.Domain.Interfaces.Services;
using GEPV.Domain.Repository;
using GEPV.Domain.Services;
using GEPV.Domain.SQL;
using GEPV.Domain.Util;
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
            this.UpdateBag();

            var vendedores = new Consultas().GetVendedores();
            var clientes = new Consultas().GetClientes();

            foreach (var item in vendedores)
            {
                item.QtdeCliente = clientes.Where(x => x.IdVendedor == item.IdVendedor).Count();
            }

            ViewBag.Vendedores = vendedores;
            ViewBag.Clientes = clientes;
            ViewBag.Usuario = HttpContext.Request.Cookies["displayName"].Value;
            ViewBag.IdVendedorLogado = Convert.ToInt32(HttpContext.Request.Cookies["idVendedorLogado"].Value);

            ViewBag.ClienteSelecionado = Request["idClienteSelecionado"];
            ViewBag.VendedorSelecionado = Request["idVendedorSelecionado"];

            return View();
        }

        [HttpGet]
        public ViewResult ReloadTarefas(int? idClienteSelecionado, int? idVendedorSelecionado)
        {
            this.UpdateBag();

            var vendedores = new Consultas().GetVendedores();
            var clientes = new Consultas().GetClientes();

            foreach (var item in vendedores)
            {
                item.QtdeCliente = clientes.Where(x => x.IdVendedor == item.IdVendedor).Count();
            }

            ViewBag.Vendedores = vendedores;
            ViewBag.Clientes = clientes;
            ViewBag.Usuario = HttpContext.Request.Cookies["displayName"].Value;
            ViewBag.IdVendedorLogado = Convert.ToInt32(HttpContext.Request.Cookies["idVendedorLogado"].Value);

            ViewBag.ClienteSelecionado = idClienteSelecionado ?? 0;
            ViewBag.VendedorSelecionado = idVendedorSelecionado ?? 0;

            return View();
        }

        public ActionResult PesquisarClientes(string termo)
        {
            this.UpdateBag();

            var vendedores = new Consultas().GetVendedores();
            var clientes = new Consultas().GetClientes().Where(x => Utilitario.RemoveDiacritics(x.Nome.ToUpper()).Contains(Utilitario.RemoveDiacritics(termo.ToUpper())) || Utilitario.RemoveDiacritics(x.RegiaoDescricao.ToUpper()).Contains(Utilitario.RemoveDiacritics(termo.ToUpper()))).ToList(); ;

            foreach (var item in vendedores)
            {
                item.QtdeCliente = clientes.Where(x => x.IdVendedor == item.IdVendedor).Count();
            }

            ViewBag.Vendedores = vendedores;
            ViewBag.Clientes = clientes;
            ViewBag.Usuario = HttpContext.Request.Cookies["displayName"].Value;
            ViewBag.IdVendedorLogado = Convert.ToInt32(HttpContext.Request.Cookies["idVendedorLogado"].Value);

            return View("Index");
        }

        public ActionResult RealizarTarefas(int? idCliente, int? idFornecedor)
        {
            this.UpdateBag();
            if (!idCliente.HasValue)
                return RedirectToAction("Index");

            ViewBag.Historico = new Consultas().GetHistoricoContatos(idCliente, null, idFornecedor);
            ViewBag.IdCliente = idCliente;
            ViewBag.IdVendedor = Convert.ToInt32(HttpContext.Request.Cookies["idVendedorLogado"].Value);
            if (ViewBag.IdVendedor == null)
                return RedirectToAction("Index", "Login");

            var listaFornecedores = new Consultas().GetFornecedoresPorCliente(idCliente);

            ViewBag.ListaFornecedores = new SelectList(listaFornecedores, "IdFornecedor", "Nome", idFornecedor);

            return View();
        }

        [HttpPost]
        public ViewResult Salvar(Contatos contato, int? idClienteSelecionado, int? idVendedorSelecionado)
        {
            if (contato.DataContato.Equals(DateTime.MinValue))
                contato.DataContato = DateTime.Now;

            this.UpdateBag();
            
            if (contato.Id > 0)
                Service.Update(contato);
            else
                Service.Add(contato);
            
            this.UpdateBag();

            ViewBag.Historico = new Consultas().GetHistoricoContatos(contato.IdCliente, null, contato.IdFornecedor);
            ViewBag.IdCliente = contato.IdCliente;
            ViewBag.IdVendedor = Convert.ToInt32(HttpContext.Request.Cookies["idVendedorLogado"].Value);

            var listaFornecedores = new Consultas().GetFornecedoresPorCliente(contato.IdCliente);
            ViewBag.ListaFornecedores = new SelectList(listaFornecedores, "IdFornecedor", "Nome", contato.IdFornecedor);

            ViewBag.ClienteSelecionado = idClienteSelecionado ?? 0;
            ViewBag.VendedorSelecionado = idVendedorSelecionado ?? 0;

            return View("RealizarTarefas");
        }

        [HttpGet]
        public ViewResult Detalhar(int? idcliente)
        {
            this.UpdateBag();
            if (idcliente.HasValue)
                ViewBag.Fornecedores = new Consultas().GetFornecedoresPorCliente(idcliente);

            return View();
        }

        [HttpPost]
        public ViewResult ExcluirHistorico(int idHistorico, int? idCliente, int? idFornecedor, int? idClienteSelecionado, int? idVendedorSelecionado)
        {
            Service.Delete(idHistorico);

            this.UpdateBag();

            ViewBag.Historico = new Consultas().GetHistoricoContatos(idCliente, null, idFornecedor);
            ViewBag.IdCliente = idCliente;
            ViewBag.IdVendedor = Convert.ToInt32(HttpContext.Request.Cookies["idVendedorLogado"].Value);

            var listaFornecedores = new Consultas().GetFornecedoresPorCliente(idCliente);
            ViewBag.ListaFornecedores = new SelectList(listaFornecedores, "IdFornecedor", "Nome", idFornecedor);

            ViewBag.ClienteSelecionado = idClienteSelecionado ?? 0;
            ViewBag.VendedorSelecionado = idVendedorSelecionado ?? 0;

            return View("RealizarTarefas");
        }

        [HttpPost]
        public ViewResult EditarHistorico(int idHistorico, int? idCliente, int? idFornecedor)
        {
            ViewBag.HistoricoAtual = Service.GetById(idHistorico);

            this.UpdateBag();

            ViewBag.Historico = new Consultas().GetHistoricoContatos(idCliente, null, idFornecedor);
            ViewBag.IdCliente = idCliente;
            ViewBag.IdVendedor = Convert.ToInt32(HttpContext.Request.Cookies["idVendedorLogado"].Value);

            var listaFornecedores = new Consultas().GetFornecedoresPorCliente(idCliente);
            ViewBag.ListaFornecedores = new SelectList(listaFornecedores, "IdFornecedor", "Nome", idFornecedor);

            return View("RealizarTarefas");
        }

        [HttpGet]
        public ViewResult RecuperarDetalhes(int? idCliente, int? idFornecedor)
        {
            this.UpdateBag();

            ViewBag.Historico = new Consultas().GetHistoricoContatos(idCliente, null, idFornecedor);
            ViewBag.IdCliente = idCliente;
            ViewBag.IdVendedor = Convert.ToInt32(HttpContext.Request.Cookies["idVendedorLogado"].Value);

            var listaFornecedores = new Consultas().GetFornecedoresPorCliente(idCliente);
            ViewBag.ListaFornecedores = new SelectList(listaFornecedores, "IdFornecedor", "Nome", idFornecedor);

            return View("RealizarTarefas");
        }

        public void UpdateBag()
        {
            ViewBag.Usuario = HttpContext.Request.Cookies["displayName"].Value;
            ViewBag.IdVendedorLogado = Convert.ToInt32(HttpContext.Request.Cookies["idVendedorLogado"].Value);
            ViewBag.DataAtual = new Consultas().GetDataHoraAtual().ToString("dd/MM/yyyy");
        }


    }
}