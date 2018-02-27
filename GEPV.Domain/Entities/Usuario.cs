using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPV.Domain.Entities
{
    [Table("USUARIO")]
    public class Usuario
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("USUARIO")]
        public string Login { get; set; }
        [Column("SENHA")]
        public string Senha { get; set; }
    }
}
