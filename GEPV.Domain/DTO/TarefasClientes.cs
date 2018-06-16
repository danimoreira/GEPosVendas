using GEPV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GEPV.Domain.DTO
{
    public class TarefasClientes
    {
        public int IdCliente { get; set; }
        public string CorCliente { get; set; }
        public string Nome { get; set; }
        public string RegiaoDescricao { get; set; }
        public List<Fornecedor> Fornecedores { get; set; }
        public DateTime? UltimoContato { get; set; }
        public DateTime? UltimaCompra { get; set; }
        public DateTime? ProximoContato { get; set; }
        public string Contato { get; set; }
        public string Responsavel { get; set; }
        public string Email { get; set; }
        public int? IdVendedor { get; set; }        
    }
}