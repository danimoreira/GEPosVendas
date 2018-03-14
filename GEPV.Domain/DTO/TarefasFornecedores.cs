using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GEPV.Domain.DTO
{
    public class TarefasFornecedores
    {
        public int IdFornecedor { get; set; }
        public int IdCliente { get; set; }
        public string CorFornecedorCliente { get; set; }
        public DateTime? UltimoContato { get; set; }
        public DateTime? UltimaCompra { get; set; }
        public DateTime? ProximoContato { get; set; }
        public string Situacao { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
    }
}