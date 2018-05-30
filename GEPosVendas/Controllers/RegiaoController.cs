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
using GEPV.Domain.SQL;

namespace GEPosVendas.Controllers
{
    public class RegiaoController : Controller
    {
        private RegiaoService Service = new RegiaoService(new RegiaoRepository());

        // GET: Regiao
        public ActionResult Index()
        {
            this.UpdateBag();
            return View(Service.List());
        }

        // GET: Regiao/Details/5
        public ActionResult Details(int? id)
        {
            this.UpdateBag();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regiao regiao = Service.GetById(id.Value);
            if (regiao == null)
            {
                return HttpNotFound();
            }
            return View(regiao);
        }

        // GET: Regiao/Create
        public ActionResult Create()
        {
            this.UpdateBag();
            return View();
        }

        // POST: Regiao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao")] Regiao regiao)
        {
            this.UpdateBag();
            if (ModelState.IsValid)
            {
                Service.Add(regiao);                
                return RedirectToAction("Index");
            }

            return View(regiao);
        }

        // GET: Regiao/Edit/5
        public ActionResult Edit(int? id)
        {
            this.UpdateBag();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regiao regiao = Service.GetById(id.Value);
            if (regiao == null)
            {
                return HttpNotFound();
            }
            return View(regiao);
        }

        // POST: Regiao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] Regiao regiao)
        {
            this.UpdateBag();
            if (ModelState.IsValid)
            {
                Service.Update(regiao);
                return RedirectToAction("Index");
            }
            return View(regiao);
        }

        // GET: Regiao/Delete/5
        public ActionResult Delete(int? id)
        {
            this.UpdateBag();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regiao regiao = Service.GetById(id.Value);
            if (regiao == null)
            {
                return HttpNotFound();
            }
            return View(regiao);
        }

        // POST: Regiao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.UpdateBag();
            Regiao regiao = Service.GetById(id);
            Service.Delete(id);
            return RedirectToAction("Index");
        }

        public void UpdateBag()
        {
            ViewBag.Usuario = HttpContext.Request.Cookies["displayName"].Value;
            ViewBag.IdVendedorLogado = Convert.ToInt32(HttpContext.Request.Cookies["idVendedorLogado"].Value);
            ViewBag.DataAtual = new Consultas().GetDataHoraAtual().ToString("dd/MM/yyyy");
        }
    }
}
