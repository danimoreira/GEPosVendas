using GEPV.Domain.Entities;
using GEPV.Domain.Interfaces.Services;
using GEPV.Domain.Repository;
using GEPV.Domain.Services;
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
            List<Fornecedor> fornecedores = Service.List();
            return View(fornecedores);
        }

        // GET: Fornecedor/Details/5
        public ActionResult Details(int id)
        {
            Fornecedor fornecedor = Service.List().Where(x => x.Id == id).FirstOrDefault();
            return View(fornecedor);
        }

        // GET: Fornecedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Fornecedor fornecedor = new Fornecedor();

                fornecedor.NomeFantasia = collection["NOME_FANTASIA"];
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
            Fornecedor fornecedor = Service.List().Where(x => x.Id == id).FirstOrDefault();
            return View(fornecedor);
        }

        // POST: Fornecedor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Fornecedor fornecedor = new Fornecedor();

                fornecedor.Id = id;
                fornecedor.NomeFantasia = collection["NOME_FANTASIA"];
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
            Fornecedor fornecedor = Service.List().Where(x => x.Id == id).FirstOrDefault();
            return View(fornecedor);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
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
    }
}
