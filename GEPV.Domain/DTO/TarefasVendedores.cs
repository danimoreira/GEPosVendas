using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GEPV.Domain.DTO
{
    public class TarefasVendedores
    {
        public int IdVendedor { get; set; }
        public string NomeVendedor { get; set; }
        public int? QtdeCliente { get; set; }
    }
}