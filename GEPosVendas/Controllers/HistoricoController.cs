using GEPV.Domain.DTO;
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
    public class HistoricoController : Controller
    {
        private ClienteService ClienteService = new ClienteService(new ClienteRepository());
        private VendedorService VendedorService = new VendedorService(new VendedorRepository());

        // GET: Historico
        public ActionResult Index()
        {
            UpdateBag();

            return View();
        }

        public ActionResult Pesquisar(int? idCliente, int? idVendedor)
        {
            ViewBag.Historico = new Consultas().GetHistoricoContatos(idCliente, idVendedor);

            UpdateBag();

            return View("Index");
        }

        private void UpdateBag()
        {
            ViewBag.idCliente = ClienteService.List().Select(x => new SelectListItem()
            {
                Text = x.RazaoSocial,
                Value = x.Id.ToString()
            }).ToList().OrderBy(y => y.Text);            

            ViewBag.idVendedor = VendedorService.List().Select(x => new SelectListItem()
            {
                Text = x.Nome,
                Value = x.Id.ToString()
            }).ToList().OrderBy(y => y.Text);
        }
    }
}