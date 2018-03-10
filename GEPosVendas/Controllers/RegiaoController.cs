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
    public class RegiaoController : Controller
    {
        private RegiaoService Service = new RegiaoService(new RegiaoRepository());

        // GET: Regiao
        public ActionResult Index()
        {
            return View(Service.List());
        }

        // GET: Regiao/Details/5
        public ActionResult Details(int? id)
        {
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
            return View();
        }

        // POST: Regiao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao")] Regiao regiao)
        {
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
            Regiao regiao = Service.GetById(id);
            Service.Delete(id);
            return RedirectToAction("Index");
        }       
    }
}
