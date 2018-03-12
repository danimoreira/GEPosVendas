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
    public class CompradorController : Controller
    {
        private VendedorService Service = new VendedorService(new VendedorRepository());

        // GET: Comprador
        public ActionResult Index()
        {
            return View(Service.List());
        }

        // GET: Comprador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendedor comprador = Service.GetById(id.Value);
            if (comprador == null)
            {
                return HttpNotFound();
            }
            return View(comprador);
        }

        // GET: Comprador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comprador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,DataNascimento,Email,Login,Senha")] Vendedor comprador)
        {
            if (ModelState.IsValid)
            {
                Service.Add(comprador);
                return RedirectToAction("Index");
            }

            return View(comprador);
        }

        // GET: Comprador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendedor comprador = Service.GetById(id.Value);
            if (comprador == null)
            {
                return HttpNotFound();
            }
            return View(comprador);
        }

        // POST: Comprador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,DataNascimento,Email,Login,Senha")] Vendedor comprador)
        {
            if (ModelState.IsValid)
            {
                Service.Update(comprador);
                return RedirectToAction("Index");
            }
            return View(comprador);
        }

        // GET: Comprador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendedor comprador = Service.GetById(id.Value);
            if (comprador == null)
            {
                return HttpNotFound();
            }
            return View(comprador);
        }

        // POST: Comprador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendedor comprador = Service.GetById(id);
            Service.Delete(comprador);
            return RedirectToAction("Index");
        }
    }
}
