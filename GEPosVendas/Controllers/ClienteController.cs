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
        private VendedorService VendedorService = new VendedorService(new VendedorRepository());

        // GET: Cliente
        public ActionResult Index()
        {
            this.UpdateBag();
            var cliente = Service.List();
            return View(cliente);
        }

        public ActionResult Pesquisar(string termo)
        {
            this.UpdateBag();
            if (string.IsNullOrEmpty(termo))
                return HttpNotFound();

            List<Cliente> cliente = Service.List().Where(x => x.RazaoSocial.ToUpper().Contains(termo.ToUpper()) || x.Cnpj.Contains(termo) || x.Regiao.Descricao.Contains(termo)).ToList();

            return View(cliente);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            this.UpdateBag();
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
            this.UpdateBag();
            ViewBag.IdEstado = new SelectList(EstadoService.List().OrderBy(m => m.Sigla), "Id", "Sigla");            
            ViewBag.IdRegiao = new SelectList(RegiaoService.List().OrderBy(m => m.Descricao), "Id", "Descricao");
            ViewBag.IdVendedor = new SelectList(VendedorService.List().OrderBy(m => m.Nome), "Id", "Nome");
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RazaoSocial,NomeFantasia,Cnpj,InscricaoEstadual,TelefonePrincipal,TelefoneContato,EmailPrincipal,EmailNFe,Observacao,Logradouro,Numero,Bairro,Cep,Cidade,IdEstado,IdRegiao,IdVendedor,NomeComprador")] Cliente cliente)
        {
            this.UpdateBag();
            if (ModelState.IsValid)
            {
                Service.Add(cliente);
                return RedirectToAction("Index");
            }

            ViewBag.IdEstado = new SelectList(EstadoService.List().OrderBy(m => m.Sigla), "Id", "Sigla");
            ViewBag.IdRegiao = new SelectList(RegiaoService.List().OrderBy(m => m.Descricao), "Id", "Descricao");
            ViewBag.IdVendedor = new SelectList(VendedorService.List().OrderBy(m => m.Nome), "Id", "Nome");
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            this.UpdateBag();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = Service.GetById(id.Value);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstado = new SelectList(EstadoService.List().OrderBy(m => m.Descricao), "Id", "Descricao", cliente.IdEstado );
            ViewBag.IdRegiao = new SelectList(RegiaoService.List().OrderBy(m => m.Descricao), "Id", "Descricao", cliente.IdRegiao);
            ViewBag.IdVendedor = new SelectList(VendedorService.List().OrderBy(m => m.Nome), "Id", "Nome", cliente.IdVendedor);
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RazaoSocial,NomeFantasia,Cnpj,InscricaoEstadual,TelefonePrincipal,TelefoneContato,EmailPrincipal,EmailNFe,Observacao,Logradouro,Numero,Bairro,Cep,Cidade,IdEstado,IdRegiao,IdVendedor,NomeComprador")] Cliente cliente)
        {
            this.UpdateBag();
            if (ModelState.IsValid)
            {
                Service.Update(cliente);
                return RedirectToAction("Index");
            }
            ViewBag.IdEstado = new SelectList(EstadoService.List().OrderBy(m => m.Sigla), "Id", "Sigla", cliente.IdEstado);
            ViewBag.IdRegiao = new SelectList(RegiaoService.List().OrderBy(m => m.Descricao), "Id", "Descricao", cliente.IdRegiao);
            ViewBag.IdVendedor = new SelectList(VendedorService.List().OrderBy(m => m.Nome), "Id", "Nome", cliente.IdVendedor);
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            this.UpdateBag();
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
            this.UpdateBag();
            Cliente cliente = Service.GetById(id);
            Service.Delete(cliente);
            return RedirectToAction("Index");
        }

        public void UpdateBag()
        {
            ViewBag.Usuario = HttpContext.Request.Cookies["displayName"].Value;
            ViewBag.IdVendedorLogado = Convert.ToInt32(HttpContext.Request.Cookies["idVendedorLogado"].Value);
        }
    }
}
