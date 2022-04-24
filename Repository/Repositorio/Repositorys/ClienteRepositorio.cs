using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using DomainService.Dominio.Entidades.DTO;
using DomainService.Dominio.Interfaces.Repository;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MySql.Data.MySqlClient;
using Repository.Repositorio.Repositorys;
using WebApplication3.Dominio.Interfaces.Repository;

namespace WebApplication3.Repositorio.Repositorys
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private IBaseRepositorio _repositorio;
        public  ClienteRepositorio(IBaseRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public bool CadastrarCliente(ClienteDTO usuario)
        {
            string sql = @"INSERT INTO Cliente (cpf,nome,endereco,telefone,dataNascimento)
                            VALUES (@CPF,@Nome,@Endereco,@telefone,@dataNascimento
                        )";
            bool retorno = false;
            //Database database = DatabaseFactory.CreateDatabase("Biblioteca");
            using (var connection = _repositorio.connection())
            {
                using (MySqlCommand comando = new MySqlCommand(sql, connection))
                {
                    
                    comando.Parameters.AddWithValue("CPF", usuario.CPF);
                    comando.Parameters.AddWithValue("Nome", usuario.nome);
                    comando.Parameters.AddWithValue("dataNascimento", usuario.dataNascimento);
                    comando.Parameters.AddWithValue("Endereco", usuario.endereco);
                    comando.Parameters.AddWithValue("telefone", usuario.telefone);
                    retorno = comando.ExecuteNonQuery() > 0;

                    comando.Dispose();
                }
            }
            
            return retorno;
        }
        public bool AlterarCliente(AlterarClienteDTO usuario)
        {
            string sql = @"UPDATE Cliente SET
                                CPF = @CPF
                                ,Nome = @Nome
                                ,Endereco = @Endereco
                                ,Telefone = @telefone,
                                dataNascimento = @dataNascimento
                            WHERE id = @idUsuario 
                        ";
            
            bool retorno = false;
            using (var connection = _repositorio.connection())
            {
                using (MySqlCommand comando = new MySqlCommand(sql, connection))
                {

                    comando.Parameters.AddWithValue("idUsuario", usuario.idUsuario);
                    comando.Parameters.AddWithValue("CPF", usuario.CPF);
                    comando.Parameters.AddWithValue("Nome", usuario.nome);
                    comando.Parameters.AddWithValue("dataNascimento", usuario.dataNascimento);
                    comando.Parameters.AddWithValue("Endereco", usuario.endereco);
                    comando.Parameters.AddWithValue("telefone", usuario.telefone);
                    retorno = comando.ExecuteNonQuery() > 0;

                    comando.Dispose();
                }
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
                            ,dataNascimento
                            ,possuiMulta
                            ,qtdeEmprestimosAtivos
                            FROM Cliente WHERE id = @idUsuario
                            AND ativo = true
                          ";

            ClienteDTO retorno = null;

            using (var connection = _repositorio.connection())
            {
                using (MySqlCommand comando = new MySqlCommand(sql, connection))
                {

                    comando.Parameters.AddWithValue("idUsuario", idUsuario);
                   
                    var dr= comando.ExecuteReader();
                    if (dr.Read())
                    {
                        retorno = new ClienteDTO()
                        {
                            nome = dr["nome"].ToString(),
                            CPF = dr["cpf"].ToString(),
                            endereco = dr["endereco"].ToString(),
                            telefone = dr["telefone"].ToString(),
                            dataNascimento = Convert.ToDateTime(dr["dataNascimento"]),
                            possuiMulta = Convert.ToBoolean(dr["possuiMulta"]),
                            qtdeEmprestimosAtivos = Convert.ToInt32(dr["qtdeEmprestimosAtivos"]),
                        };
                    }

                    comando.Dispose();
                }
            }

            return retorno;
        }
        public List<ClienteDTO> ListarCliente()
        {
            string sql = @"SELECT 
                            nome
                            ,cpf
                            ,endereco
                            ,telefone
                            ,dataNascimento
                            ,possuiMulta
                            ,qtdeEmprestimosAtivos
                            FROM Cliente 
                            WHERE ativo = true
                          ";

            List<ClienteDTO> retorno = new List<ClienteDTO>();

            using (var connection = _repositorio.connection())
            {
                using (MySqlCommand comando = new MySqlCommand(sql, connection))
                {
                    var dr = comando.ExecuteReader();
                    while (dr.Read())
                    {
                        retorno.Add( new ClienteDTO()
                        {
                            nome = dr["nome"].ToString(),
                            CPF = dr["cpf"].ToString(),
                            endereco = dr["endereco"].ToString(),
                            telefone = dr["telefone"].ToString(),
                            dataNascimento = Convert.ToDateTime(dr["dataNascimento"]),
                            possuiMulta = Convert.ToBoolean(dr["possuiMulta"]),
                            qtdeEmprestimosAtivos = Convert.ToInt32(dr["qtdeEmprestimosAtivos"]),
                        });
                    }

                    comando.Dispose();
                }
            }

            return retorno;
        }

        public bool ExcluirCliente(int idUsuario)
        {
            string sql = @"UPDATE Cliente SET
                                ativo = false
                            WHERE id = @idUsuario 
                        ";

            bool retorno = false;

            using (var connection = _repositorio.connection())
            {
                using (MySqlCommand comando = new MySqlCommand(sql, connection))
                {
                    comando.Parameters.AddWithValue("idUsuario", idUsuario);
                    retorno = comando.ExecuteNonQuery() > 0;

                    comando.Dispose();
                }
            }
            return retorno;
        }

    }
}
