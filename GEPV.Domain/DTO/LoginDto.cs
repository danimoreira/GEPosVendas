using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPV.Domain.DTO
{
    public class LoginDto
    {
        [DisplayName("Usuário")]
        [Required(ErrorMessage ="Usuário/Senha inválidos!")]
        public string Usuario { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "Usuário/Senha inválidos!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

    }
}
