using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPV.Domain.Entities
{
    [Table("FORNECEDOR_POR_CLIENTE")]
    public class FornecedorPorCliente
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("ID_FORNECEDOR")]        
        [ForeignKey("Fornecedor")]
        [Display(Name = "Fornecedor")]
        public int IdFornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        
        [Column("ID_CLIENTE")]
        [ForeignKey("Cliente")]
        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        
    }
}
