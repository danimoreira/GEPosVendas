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
        public string RazaoSocial { get; set; }
        [Column("NOME_FANTASIA")]
        public string NomeFantasia { get; set; }
        [Column("CNPJ")]
        public string Cnpj { get; set; }
        [Column("INSCRICAO_ESTADUAL")]
        public string InscricaoEstadual { get; set; }
        [Column("TELEFONE_PRINCIPAL")]
        public string TelefonePrincipal { get; set; }
        [Column("TELEFONE_CONTATO")]
        public string TelefoneContato { get; set; }
        [Column("EMAIL_PRINCIPAL")]
        public string EmailPrincipal { get; set; }
        [Column("EMAIL_NFE")]
        public string EmailNFe { get; set; }
        [Column("OBSERVACAO")]
        public string Observacao { get; set; }
        [Column("LOGRADOURO")]
        public string Logradouro { get; set; }
        [Column("NUMERO")]
        public string Numero { get; set; }
        [Column("BAIRRO")]
        public string Bairro { get; set; }
        [Column("CEP")]
        public string Cep { get; set; }
        [Column("CIDADE")]
        public string Cidade { get; set; }

        [Column("ID_ESTADO")]
        [ForeignKey("Estado")]
        public int IdEstado { get; set; }
        public virtual Estado Estado { get; set; }

        [Column("ID_REGIAO")]
        [ForeignKey("Regiao")]
        public int IdRegiao { get; set; }
        public virtual Regiao Regiao { get; set; }

    }
}
