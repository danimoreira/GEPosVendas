using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPV.Domain.Entities
{
    [Table("FORNECEDOR")]
    public class Fornecedor
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("NOME_FANTASIA")]
        public String NOME_FANTASIA { get; set; }
        [Column("SIGLA_FORNECEDOR")]
        public string Sigla { get; set; }
        [Column("OBSERVACAO")]
        public string Observacao { get; set; }
    }
}
