using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPV.Domain.Entities
{
    [Table("CLIENTE")]
    public class Cliente
    {
        public Cliente()
        {
            
        }

        [Column("ID")]
        [Key]
        public int Id { get; set; }
        [Column("RAZAO_SOCIAL")]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }
        [Column("NOME_FANTASIA")]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }
        [Column("CNPJ")]
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }
        [Column("INSCRICAO_ESTADUAL")]
        [Display(Name = "Inscrição Estadual")]
        public string InscricaoEstadual { get; set; }
        [Column("TELEFONE_PRINCIPAL")]
        [Display(Name = "Telefone Principal")]
        public string TelefonePrincipal { get; set; }
        [Column("TELEFONE_CONTATO")]
        [Display(Name = "Telefone Contato")]
        public string TelefoneContato { get; set; }
        [Column("EMAIL_PRINCIPAL")]
        [Display(Name = "Email Principal")]
        public string EmailPrincipal { get; set; }
        [Column("EMAIL_NFE")]
        [Display(Name = "Email NFe")]
        public string EmailNFe { get; set; }
        [Column("OBSERVACAO")]
        [Display(Name = "Observação")]
        public string Observacao { get; set; }
        [Column("LOGRADOURO")]
        [Display(Name = "Endereço")]
        public string Logradouro { get; set; }
        [Column("NUMERO")]
        [Display(Name = "Nº")]
        public string Numero { get; set; }
        [Column("BAIRRO")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }
        [Column("CEP")]
        [Display(Name = "CEP")]
        public string Cep { get; set; }
        [Column("CIDADE")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Column("ID_ESTADO")]
        [ForeignKey("Estado")]
        [Display(Name = "Estado")]
        public int IdEstado { get; set; }
        public virtual Estado Estado { get; set; }

        [Column("ID_REGIAO")]
        [ForeignKey("Regiao")]
        [Display(Name = "Região")]
        public int IdRegiao { get; set; }
        public virtual Regiao Regiao { get; set; }

        [Column("NOME_COMPRADOR")]
        [Display(Name = "Comprador")]
        public string NomeComprador { get; set; }

        [Column("ID_VENDEDOR")]
        [ForeignKey("Vendedor")]
        [Display(Name = "Vendedor")]
        public int? IdVendedor { get; set; }
        public virtual Vendedor Vendedor { get; set; }        
    }
}
