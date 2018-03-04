using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPV.Domain.Entities
{
    [Table("ESTADO")]
    public class Estado
    {
        [Column("ID")]
        [Key]
        public int MyProperty { get; set; }
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
        [Column("SIGLA")]
        public string Sigla { get; set; }
    }
}
