﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPV.Domain.Entities
{
    [Table("VENDEDOR")]
    public class Vendedor
    {
        public Vendedor()
        {
            
        }
        [Column("ID")]
        [Key]
        public int Id { get; set; }
        [Column("NOME")]
        public string Nome { get; set; }
        [Column("DATA_NASCIMENTO")]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
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
