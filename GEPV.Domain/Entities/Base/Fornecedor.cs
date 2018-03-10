using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        public int Id { get; set; }
        [Column("NOME_FANTASIA")]
        [Display(Name = "Nome Fantasia")]
        public String NomeFantasia { get; set; }
        [Column("SIGLA_FORNECEDOR")]
        [Display(Name = "Sigla")]
        public string Sigla { get; set; }
        [Column("OBSERVACAO")]
        [Display(Name = "Observação")]
        public string Observacao { get; set; }
    }
}
