using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GEPV.Domain.Entities;
using GEPV.Domain.Repository;
using GEPV.Domain.Services;

namespace GEPosVendas.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteService Service = new ClienteService(new ClienteRepository());
        private EstadoService EstadoService = new EstadoService(new EstadoRepository());
        private RegiaoService RegiaoService = new RegiaoService(new RegiaoRepository());

        // GET: Cliente
        public ActionResult Index()
        {
            var cliente = Service.List();
            return View(cliente);
        }

        public ActionResult Pesquisar(string termo)
        {
            if (string.IsNullOrEmpty(termo))
                return HttpNotFound();

            List<Cliente> cliente = Service.List().Where(x => x.RazaoSocial.ToUpper().Contains(termo.ToUpper()) || x.Cnpj.Contains(termo)).ToList();

            return View(cliente);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = Service.GetById(id.Value);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.IdEstado = new SelectList(EstadoService.List().OrderBy(m => m.Sigla), "Id", "Sigla");            
            ViewBag.IdRegiao = new SelectList(RegiaoService.List().OrderBy(m => m.Descricao), "Id", "Descricao");
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RazaoSocial,NomeFantasia,Cnpj,InscricaoEstadual,TelefonePrincipal,TelefoneContato,EmailPrincipal,EmailNFe,Observacao,Logradouro,Numero,Bairro,Cep,Cidade,IdEstado,IdRegiao")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                Service.Add(cliente);
                return RedirectToAction("Index");
            }

            ViewBag.IdEstado = new SelectList(EstadoService.List().OrderBy(m => m.Sigla), "Id", "Sigla");
            ViewBag.IdRegiao = new SelectList(RegiaoService.List().OrderBy(m => m.Descricao), "Id", "Descricao");
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = Service.GetById(id.Value);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstado = new SelectList(EstadoService.List().OrderBy(m => m.Sigla), "Id", "Sigla");
            ViewBag.IdRegiao = new SelectList(RegiaoService.List().OrderBy(m => m.Descricao), "Id", "Descricao");
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RazaoSocial,NomeFantasia,Cnpj,InscricaoEstadual,TelefonePrincipal,TelefoneContato,EmailPrincipal,EmailNFe,Observacao,Logradouro,Numero,Bairro,Cep,Cidade,IdEstado,IdRegiao")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                Service.Update(cliente);
                return RedirectToAction("Index");
            }
            ViewBag.IdEstado = new SelectList(EstadoService.List().OrderBy(m => m.Sigla), "Id", "Sigla");
            ViewBag.IdRegiao = new SelectList(RegiaoService.List().OrderBy(m => m.Descricao), "Id", "Descricao");
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = Service.GetById(id.Value);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = Service.GetById(id);
            Service.Delete(cliente);
            return RedirectToAction("Index");
        }        
    }
}
