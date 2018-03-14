using GEPV.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPV.Domain.SQL
{
    public class Consultas
    {
        private Entities.GEPVEntities db = new Entities.GEPVEntities();

        public List<TarefasVendedores> GetVendedores()
        {
            string SQl = @"select
	                            VENDEDOR.ID IdVendedor,
                                VENDEDOR.NOME NomeVendedor
                            from VENDEDOR";

            return db.Database.SqlQuery<TarefasVendedores>(SQl).ToList();
        }

        public List<TarefasClientes> GetClientes()
        {
            string SQL = @"SELECT  CLIENTE.Id IdCliente,
                                   'cliente-em-dia' CorCliente,
                                                    CLIENTE.RAZAO_SOCIAL Nome,
                                                    REGIAO.DESCRICAO RegiaoDescricao,
                                                    FORNECEDOR.*,
                                                    MAX(CONTATOS.DATA_CONTATO) UltimoContato,
                                                    MAX(CONTATOS.DATA_COMPRA) UltimaCompra,
                                                    MAX(CONTATOS.DATA_REAGENDA) ProximoContato,
                                                    CLIENTE.TELEFONE_PRINCIPAL + '/' + CLIENTE.TELEFONE_CONTATO Contato,
                                                    CLIENTE.NOME_COMPRADOR Responsavel,
                                                    CLIENTE.EMAIL_PRINCIPAL Email,
                                                    CLIENTE.ID_VENDEDOR IdVendedor
                            FROM CLIENTE                            
                            INNER JOIN FORNECEDOR_POR_CLIENTE FPC ON FPC.ID_CLIENTE = CLIENTE.ID 
                            INNER JOIN FORNECEDOR ON FPC.ID_FORNECEDOR = FORNECEDOR.ID
                            LEFT JOIN CONTATOS ON CONTATOS.ID_CLIENTE = CLIENTE.ID AND FORNECEDOR.ID = CONTATOS.ID_FORNECEDOR
                            INNER JOIN REGIAO ON REGIAO.ID = CLIENTE.ID_REGIAO
                            GROUP BY CLIENTE.Id,
                                     CLIENTE.RAZAO_SOCIAL,
                                     REGIAO.DESCRICAO,
                                     CLIENTE.TELEFONE_PRINCIPAL,
                                     CLIENTE.TELEFONE_CONTATO,
                                     CLIENTE.NOME_COMPRADOR,
                                     CLIENTE.EMAIL_PRINCIPAL";

            return db.Database.SqlQuery<TarefasClientes>(SQL).ToList();
        }

        public List<TarefasFornecedores> GetFornecedoresPorCliente()
        {
            string SQL = @"SELECT CLIENTE.ID IDCLIENTE,
                                   '' CORFORNECEDORCLIENTE,
                                   FORNECEDOR.ID IDFORNECEDOR,
                                   FORNECEDOR.NOME_FANTASIA NOME,
                                   FORNECEDOR.SIGLA_FORNECEDOR SIGLA,
                                   MAX(CONTATOS.DATA_CONTATO) ULTIMOCONTATO,
                                   MAX(CONTATOS.DATA_COMPRA) ULTIMACOMPRA,
                                   MAX(CONTATOS.DATA_AGENDA) PROXIMOCONTATO,
                                   '' SITUACAO
                            FROM FORNECEDOR
                            INNER JOIN FORNECEDOR_POR_CLIENTE FPC ON FPC.ID_FORNECEDOR = FORNECEDOR.ID 
                            INNER JOIN CLIENTE ON FPC.ID_CLIENTE = CLIENTE.ID
                            LEFT JOIN CONTATOS ON CONTATOS.ID_FORNECEDOR = FORNECEDOR.ID AND CONTATOS.ID_CLIENTE = CLIENTE.ID                            
                            GROUP BY CLIENTE.ID,
                                     FORNECEDOR.ID,
                                     FORNECEDOR.NOME_FANTASIA,
                                     FORNECEDOR.SIGLA_FORNECEDOR";

            return db.Database.SqlQuery<TarefasFornecedores>(SQL).ToList();
        }

    }
}
