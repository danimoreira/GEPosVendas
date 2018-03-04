using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPV.Domain.Entities
{
    [Table("REGIAO")]
    public class Regiao
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }

        [Column("DESCRICAO")]
        public string Descricao { get; set; }

    }
}
