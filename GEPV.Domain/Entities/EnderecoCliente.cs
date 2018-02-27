using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPV.Domain.Entities
{
    [Table("ENDERECO_CLIENTE")]
    public class EnderecoCliente
    {
        public EnderecoCliente()
        {
            Cliente = new Cliente();
        }

        [Column("ID")]
        public int Id { get; set; }        
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
        public int IdEstado { get; set; }
        [Column("ID_REGIAO")]
        public int IdRegiao { get; set; }
        [Column("IND_ENDERECO_ENTREGA")]
        public bool IndEnderecoEntrega { get; set; }
        [Column("ID_CLIENTE")]
        [ForeignKey("CLIENTE")]
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
