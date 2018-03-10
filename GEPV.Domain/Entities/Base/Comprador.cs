﻿using System;
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
        [Display(Name = "Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }
        [Column("EMAIL")]
        [Display(Name = "Email")]
        public string Email { get; set; }        
        [Column("USUARIO")]
        [Display(Name = "Usuário")]
        public string Login { get; set; }
        [Column("SENHA")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
