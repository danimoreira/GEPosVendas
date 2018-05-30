using GEPV.Domain.Entities;
using GEPV.Domain.Interfaces.Services;
using GEPV.Domain.Repository;
using GEPV.Domain.Services;
using GEPV.Domain.SQL;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GEPosVendas.Controllers
{
    public class FornecedorController : Controller
    {
        private FornecedorService Service = new FornecedorService(new FornecedorRepository());

        // GET: Fornecedor
        public ActionResult Index()
        {
            this.UpdateBag();
            List<Fornecedor> fornecedores = Service.List();
            return View(fornecedores);
        }

        // GET: Fornecedor/Details/5
        public ActionResult Details(int id)
        {
            this.UpdateBag();
            Fornecedor fornecedor = Service.List().Where(x => x.Id == id).FirstOrDefault();
            return View(fornecedor);
        }

        // GET: Fornecedor/Create
        public ActionResult Create()
        {
            this.UpdateBag();
            return View();
        }

        // POST: Fornecedor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                this.UpdateBag();
                // TODO: Add insert logic here
                Fornecedor fornecedor = new Fornecedor();

                fornecedor.NomeFantasia = collection["NomeFantasia"];
                fornecedor.Sigla = collection["Sigla"];
                fornecedor.Observacao = collection["Observacao"];

                Service.Add(fornecedor);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fornecedor/Edit/5
        public ActionResult Edit(int id)
        {
            this.UpdateBag();
            Fornecedor fornecedor = Service.List().Where(x => x.Id == id).FirstOrDefault();
            return View(fornecedor);
        }

        // POST: Fornecedor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                this.UpdateBag();
                // TODO: Add update logic here
                Fornecedor fornecedor = new Fornecedor();

                fornecedor.Id = id;
                fornecedor.NomeFantasia = collection["NomeFantasia"];
                fornecedor.Sigla = collection["Sigla"];
                fornecedor.Observacao = collection["Observacao"];

                Service.Update(fornecedor);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fornecedor/Delete/5
        public ActionResult Delete(int id)
        {
            this.UpdateBag();
            Fornecedor fornecedor = Service.List().Where(x => x.Id == id).FirstOrDefault();
            return View(fornecedor);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                this.UpdateBag();
                // TODO: Add delete logic here
                Fornecedor fornecedor = Service.List().Where(x => x.Id == id).FirstOrDefault();

                Service.Delete(fornecedor);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void UpdateBag()
        {
            ViewBag.Usuario = HttpContext.Request.Cookies["displayName"].Value;
            ViewBag.IdVendedorLogado = Convert.ToInt32(HttpContext.Request.Cookies["idVendedorLogado"].Value);
            ViewBag.DataAtual = new Consultas().GetDataHoraAtual().ToString("dd/MM/yyyy");
        }
    }
}
