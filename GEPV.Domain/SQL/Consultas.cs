using GEPV.Domain.DTO;
using GEPV.Domain.Entities;
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
		                            CASE WHEN SUM(CONT_ATRASO) > 0 THEN 'bg-danger'
                                     WHEN SUM(CONT_DIA) > 0 AND SUM(CONT_ATRASO) = 0 THEN 'bg-warning'
                                     WHEN SUM(CONT_REALIZADO) > 0 AND SUM(CONT_DIA) = 0 AND SUM(CONT_ATRASO) = 0 THEN 'bg-success'
                                     WHEN CONTATOS.ID_CLIENTE IS NULL THEN 'bg-light'
                                     ELSE 'bg-info' END CorCliente,
		                            CLIENTE.RAZAO_SOCIAL Nome,
		                            REGIAO.DESCRICAO RegiaoDescricao,
		                            MAX(CONTATOS.DATA_CONTATO) UltimoContato,
		                            MAX(CONTATOS.DATA_COMPRA) UltimaCompra,
		                            MIN(CONTATOS.DATA_AGENDA) ProximoContato,
		                            CLIENTE.TELEFONE_PRINCIPAL Contato,
		                            CLIENTE.NOME_COMPRADOR Responsavel,
		                            CLIENTE.EMAIL_PRINCIPAL Email,
		                            CLIENTE.ID_VENDEDOR IdVendedor
                            FROM CLIENTE                            
                            INNER JOIN FORNECEDOR_POR_CLIENTE FPC ON FPC.ID_CLIENTE = CLIENTE.ID 
                            LEFT OUTER JOIN (SELECT 
				                            ID_CLIENTE,
                                            ID_FORNECEDOR,
				                            CASE WHEN DATE(MAX(CONTATOS.DATA_AGENDA)) < DATE(NOW()) THEN 1 ELSE 0 END CONT_ATRASO,
                                            CASE WHEN DATE(MAX(CONTATOS.DATA_AGENDA)) = DATE(NOW()) THEN 1 ELSE 0 END CONT_DIA,
                                            CASE WHEN DATE(MAX(CONTATOS.DATA_AGENDA)) < DATE(NOW()) THEN 1 ELSE 0 END CONT_REALIZADO, 
                                            CASE WHEN DATE(MAX(CONTATOS.DATA_AGENDA)) IS NULL THEN 1 ELSE 0 END CONT_NAO_REALIZADO,                
				                            MAX(DATA_CONTATO) DATA_CONTATO,
				                            MAX(DATA_COMPRA) DATA_COMPRA,
				                            MAX(DATA_AGENDA) DATA_AGENDA
			                            FROM CONTATOS
			                            GROUP BY ID_CLIENTE,
					                             ID_FORNECEDOR
                             )CONTATOS ON CONTATOS.ID_CLIENTE = CLIENTE.ID AND FPC.ID_FORNECEDOR = CONTATOS.ID_FORNECEDOR
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

        public List<TarefasFornecedores> GetFornecedoresPorCliente(int? idCliente = 0)
        {
            string SQL = string.Format(@"SELECT CLIENTE.ID IDCLIENTE,
                                    CASE WHEN DATE(MAX(CONTATOS.DATA_AGENDA)) > DATE(NOW()) AND DATE(MAX(CONTATOS.DATA_CONTATO)) = DATE(NOW()) THEN 'bg-success'
		                            WHEN DATE(MAX(CONTATOS.DATA_AGENDA)) = DATE(NOW()) THEN 'bg-warning'
		                            WHEN DATE(MAX(CONTATOS.DATA_AGENDA)) < DATE(NOW()) THEN 'bg-danger'
		                            WHEN DATE(MAX(CONTATOS.DATA_AGENDA)) IS NULL THEN 'bg-light'
		                            ELSE 'bg-info'
		                            END CORFORNECEDORCLIENTE,                                    
                                   FORNECEDOR.ID IDFORNECEDOR,
                                   FORNECEDOR.NOME_FANTASIA NOME,
                                   FORNECEDOR.SIGLA_FORNECEDOR SIGLA,
                                   MAX(CONTATOS.DATA_CONTATO) ULTIMOCONTATO,
                                   MAX(CONTATOS.DATA_COMPRA) ULTIMACOMPRA,
                                   MAX(CONTATOS.DATA_AGENDA) PROXIMOCONTATO,
                                   CASE WHEN DATE(MAX(CONTATOS.DATA_AGENDA)) > DATE(NOW()) AND DATE(MAX(CONTATOS.DATA_CONTATO)) = DATE(NOW()) THEN 'CONTATO REALIZADO'
                                    WHEN DATE(MAX(CONTATOS.DATA_AGENDA)) = DATE(NOW()) THEN 'CONTATO A REALIZAR NO DIA'
                                    WHEN DATE(MAX(CONTATOS.DATA_AGENDA)) < DATE(NOW()) THEN 'CONTATO EM ATRASO'
                                    WHEN DATE(MAX(CONTATOS.DATA_AGENDA)) IS NULL THEN 'NUNCA REALIZADO CONTATO'
                                    ELSE 'CONTATO EM DIA'
                                    END SITUACAO
                            FROM FORNECEDOR
                            INNER JOIN FORNECEDOR_POR_CLIENTE FPC ON FPC.ID_FORNECEDOR = FORNECEDOR.ID 
                            INNER JOIN CLIENTE ON FPC.ID_CLIENTE = CLIENTE.ID
                            LEFT JOIN CONTATOS ON CONTATOS.ID_FORNECEDOR = FORNECEDOR.ID AND CONTATOS.ID_CLIENTE = CLIENTE.ID  
                            WHERE CLIENTE.ID = {0}
                            GROUP BY CLIENTE.ID,
                                     FORNECEDOR.ID,
                                     FORNECEDOR.NOME_FANTASIA,
                                     FORNECEDOR.SIGLA_FORNECEDOR", idCliente.Value.ToString());

            return db.Database.SqlQuery<TarefasFornecedores>(SQL).ToList();
        }

        public List<HistoricoDTO> GetHistoricoContatos(int? IdCliente, int? IdVendedor)
        {
            IdCliente = IdCliente ?? 0;
            IdVendedor = IdVendedor ?? 0;

            string SQL = string.Format(@"SELECT 
	                                        CLIENTE.ID IdCliente,
                                            CLIENTE.RAZAO_SOCIAL NomeCliente,
                                            FORNECEDOR.ID IdFornecedor,
                                            FORNECEDOR.NOME_FANTASIA NomeFornecedor,
                                            VENDEDOR.ID IdVendedor,
                                            VENDEDOR.NOME NomeVendedor,
                                            DATA_CONTATO DataContato,
                                            DATA_COMPRA DataCompra,
                                            DATA_AGENDA DataAgenda,    
                                            DESCRICAO Negociacao
                                        FROM CONTATOS
                                        INNER JOIN CLIENTE ON CONTATOS.ID_CLIENTE = CLIENTE.ID
                                        INNER JOIN VENDEDOR ON CONTATOS.ID_VENDEDOR = VENDEDOR.ID
                                        INNER JOIN FORNECEDOR ON CONTATOS.ID_FORNECEDOR = FORNECEDOR.ID
                                        WHERE (CONTATOS.ID_VENDEDOR = {0} OR {0} = 0) 
                                        AND (CONTATOS.ID_CLIENTE = {1} OR {1} = 0)", IdVendedor, IdCliente);

            return db.Database.SqlQuery<HistoricoDTO>(SQL).ToList();
        }        
    }
}
