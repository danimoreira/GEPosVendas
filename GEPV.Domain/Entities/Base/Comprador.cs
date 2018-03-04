using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPV.Domain.Entities
{
    [Table("COMPRADOR")]
    public class Comprador
    {
        public Comprador()
        {
            
        }
        [Column("ID")]
        [Key]
        public int Id { get; set; }
        [Column("NOME")]
        public string Nome { get; set; }
        [Column("DATA_NASCIMENTO")]
        public DateTime? DataNascimento { get; set; }
        [Column("EMAIL")]
        public string Email { get; set; }        
        [Column("USUARIO")]
        public string Login { get; set; }
        [Column("SENHA")]
        public string Senha { get; set; }
    }
}
