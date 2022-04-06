using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebApplication3.Dominio.Entidades.DTO;
using WebApplication3.Dominio.Interfaces.Repository;

namespace WebApplication3.Repositorio.Repositorys
{
    public class ClienteRepositorio : IClienteRepositorio
    {

        public bool CadastrarCliente(ClienteDTO usuario)
        {
            string sql = @"INSERT INTO Cliente VALUES
                            (@CPF,@Nome,@Endereco,@telefone,@dataNascimento
                        )";

            Database database = DatabaseFactory.CreateDatabase("");

            bool retorno = false;
            using (DbCommand comando = database.GetSqlStringCommand(sql.ToString()))
            {
                database.AddInParameter(comando, "@CPF", DbType.String, usuario);
                database.AddInParameter(comando, "@Nome", DbType.String, usuario);
                database.AddInParameter(comando, "@dataNascimento", DbType.DateTime, usuario);
                database.AddInParameter(comando, "@Endereco", DbType.String, usuario);
                database.AddInParameter(comando, "@telefone", DbType.String, usuario);
                retorno = database.ExecuteNonQuery(comando) > 0;

                comando.Dispose();
            }

            return retorno;
        }
        public bool AlterarCliente(ClienteDTO usuario)
        {
            string sql = @"UPDATE Cliente SET
                                CPF = @CPF
                                ,Nome = @Nome
                                ,Endereco = @Endereco
                                ,Telefone = @telefone,
                                dataNascimento = @dataNascimento
                            WHERE id = @idUsuario 
                        ";

            Database database = DatabaseFactory.CreateDatabase("");
            
            bool retorno = false;
            using (DbCommand comando = database.GetSqlStringCommand(sql.ToString()))
            {
                database.AddInParameter(comando, "@CPF", DbType.String, usuario);
                database.AddInParameter(comando, "@Nome", DbType.String, usuario);
                database.AddInParameter(comando, "@dataNascimento", DbType.DateTime, usuario);
                database.AddInParameter(comando, "@Endereco", DbType.String, usuario);
                database.AddInParameter(comando, "@telefone", DbType.String, usuario);
                database.AddInParameter(comando, "@idUsuario", DbType.Int32, usuario);
                retorno = database.ExecuteNonQuery(comando) > 0;

                comando.Dispose();
            }

            return retorno;
        }
        public ClienteDTO BuscarCliente(int idUsuario)
        {
            string sql = @"SELECT id
                            ,nome
                            ,cpf
                            ,endereco
                            ,telefone
                            ,dataNascimente
                            ,possuiMulta
                            ,qtdeEmprestimosAtivos
                            FROM Cliente WHERE id = @idUsuario
                          ";

            Database database = DatabaseFactory.CreateDatabase("");

            ClienteDTO retorno = null;
            
            using (DbCommand comando = database.GetSqlStringCommand(sql.ToString()))
            {
                database.AddInParameter(comando, "@idUsuario", DbType.Int32, idUsuario);
                using (IDataReader dr = database.ExecuteReader(comando))
                {
                    if (dr.Read())
                    {
                        retorno = new ClienteDTO(){
                            idUsuario = Convert.ToInt32(dr["id"]),
                            nome = dr["nome"].ToString(),
                            CPF = dr["cpf"].ToString(),
                            endereco = dr["endereco"].ToString(),
                            telefone = dr["telefone"].ToString(),
                            dataNascimento = Convert.ToDateTime(dr["dataNascimento"]),
                            possuiMulta = Convert.ToBoolean(dr["possuiMulta"]),
                            qtdeEmprestimosAtivos = Convert.ToInt32(dr["qtdeEmprestimosAtivos"]),

                        };
                    }
                    dr.Close();
                    dr.Dispose();
                }
                
                comando.Dispose();
            }

            return retorno;
        }
        public List<ClienteDTO> ListarCliente()
        {
            string sql = @"SELECT id
                            ,nome
                            ,cpf
                            ,endereco
                            ,telefone
                            ,dataNascimente
                            ,possuiMulta
                            ,qtdeEmprestimosAtivos
                            FROM Cliente 
                          ";

            Database database = DatabaseFactory.CreateDatabase("");

            List<ClienteDTO> retorno = new List<ClienteDTO>();

            using (DbCommand comando = database.GetSqlStringCommand(sql.ToString()))
            {
                using (IDataReader dr = database.ExecuteReader(comando))
                {
                    while (dr.Read())
                    {
                        retorno.Add(new ClienteDTO()
                        {
                            idUsuario = Convert.ToInt32(dr["id"]),
                            nome = dr["nome"].ToString(),
                            CPF = dr["cpf"].ToString(),
                            endereco = dr["endereco"].ToString(),
                            telefone = dr["telefone"].ToString(),
                            dataNascimento = Convert.ToDateTime(dr["dataNascimento"]),
                            possuiMulta = Convert.ToBoolean(dr["possuiMulta"]),
                            qtdeEmprestimosAtivos = Convert.ToInt32(dr["qtdeEmprestimosAtivos"]),

                        });
                    }
                    dr.Close();
                    dr.Dispose();
                }

                comando.Dispose();
            }

            return retorno;
        }

        public bool ExcluirCliente(int idUsuario)
        {
            string sql = @"UPDATE Cliente SET
                                ativo = false
                            WHERE id = @idUsuario 
                        ";

            Database database = DatabaseFactory.CreateDatabase("");

            bool retorno = false;
            using (DbCommand comando = database.GetSqlStringCommand(sql.ToString()))
            {
                database.AddInParameter(comando, "@idUsuario", DbType.Int32, idUsuario);
                retorno = database.ExecuteNonQuery(comando) > 0;

                comando.Dispose();
            }

            return retorno;
        }

    }
}
