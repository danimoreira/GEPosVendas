﻿using GEPV.Domain.DTO;
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
            this.UpdateBag();
            ViewBag.Vendedores = new Consultas().GetVendedores();            
            ViewBag.Clientes = new Consultas().GetClientes();
            
            ViewBag.Usuario = HttpContext.Request.Cookies["displayName"].Value;
            ViewBag.IdVendedorLogado = Convert.ToInt32(HttpContext.Request.Cookies["idVendedorLogado"].Value);

            return View();
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

            ViewBag.IdFornecedor = idFornecedor;

            return View();
        }

        [HttpPost]
        public ActionResult Salvar(Contatos contato)
        {
            if (contato.DataContato == DateTime.MinValue)
                contato.DataContato = DateTime.Now;
            
            this.UpdateBag();
            if (ModelState.IsValid)
            {
                Service.Add(contato);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Detalhar(int? idcliente)
        {
            this.UpdateBag();
            if (idcliente.HasValue)
                ViewBag.Fornecedores = new Consultas().GetFornecedoresPorCliente(idcliente);

            return View();
        }

        public void UpdateBag()
        {
            ViewBag.Usuario = HttpContext.Request.Cookies["displayName"].Value;
            ViewBag.IdVendedorLogado = Convert.ToInt32(HttpContext.Request.Cookies["idVendedorLogado"].Value);
            ViewBag.DataAtual = new Consultas().GetDataHoraAtual().ToString("dd/MM/yyyy");
        }


    }
}