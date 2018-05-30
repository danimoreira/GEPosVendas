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
    public class EstadoController : Controller
    {
        private EstadoService Service = new EstadoService(new EstadoRepository());

        // GET: Estado
        public ActionResult Index()
        {
            this.UpdateBag();
            return View(Service.List());
        }

        // GET: Estado/Details/5
        public ActionResult Details(int? id)
        {
            this.UpdateBag();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado estado = Service.GetById(id.Value);
            if (estado == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        // GET: Estado/Create
        public ActionResult Create()
        {
            this.UpdateBag();
            return View();
        }

        // POST: Estado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,Sigla")] Estado estado)
        {
            this.UpdateBag();
            if (ModelState.IsValid)
            {
                Service.Add(estado);
                return RedirectToAction("Index");
            }

            return View(estado);
        }

        // GET: Estado/Edit/5
        public ActionResult Edit(int? id)
        {
            this.UpdateBag();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado estado = Service.GetById(id.Value);
            if (estado == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        // POST: Estado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,Sigla")] Estado estado)
        {
            this.UpdateBag();
            if (ModelState.IsValid)
            {
                Service.Update(estado);
                return RedirectToAction("Index");
            }
            return View(estado);
        }

        // GET: Estado/Delete/5
        public ActionResult Delete(int? id)
        {
            this.UpdateBag();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado estado = Service.GetById(id.Value);
            if (estado == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        // POST: Estado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.UpdateBag();
            Estado estado = Service.GetById(id);
            Service.Delete(estado);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Service.Dispose();
            }
            base.Dispose(disposing);
        }

        public void UpdateBag()
        {
            ViewBag.Usuario = HttpContext.Request.Cookies["displayName"].Value;
            ViewBag.IdVendedorLogado = Convert.ToInt32(HttpContext.Request.Cookies["idVendedorLogado"].Value);
            ViewBag.DataAtual = new Consultas().GetDataHoraAtual().ToString("dd/MM/yyyy");
        }
    }
}
