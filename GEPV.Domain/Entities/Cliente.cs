using System;
using System.Collections.Generic;
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
            Enderecos = new List<EnderecoCliente>();
        }

        [Column("ID")]
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
        public virtual List<EnderecoCliente> Enderecos { get; set; }
    }
}
