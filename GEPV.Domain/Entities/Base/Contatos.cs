using GEPV.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPV.Domain.Entities
{
    [Table("CONTATOS")]
    public class Contatos
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }

        [Column("ID_COMPRADOR")]
        [ForeignKey("Comprador")]
        public int IdComprador { get; set; }
        public virtual Comprador Comprador { get; set; }

        [Column("ID_CLIENTE")]
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        [Column("ID_FORNECEDOR")]
        [ForeignKey("Fornecedor")]
        public int IdFornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }
        [Column("DATA_CONTATO")]
        public DateTime DataContato { get; set; }
        [Column("DATA_COMPRA")]
        public DateTime? DataCompra { get; set; }
        [Column("DATA_AGENDA")]
        public DateTime? DataAgenda { get; set; }
        [Column("DATA_REAGENDA")]
        public DateTime? DataReagenda { get; set; }
        [Column("SITUACAO")]
        public int Situacao { get; set; }        

        [NotMapped]
        public string DescricaoSitaucao {
            get
            {
                return Enums.GetDescription((Enums.Situacao)Situacao);
            }
        }
    }
}
