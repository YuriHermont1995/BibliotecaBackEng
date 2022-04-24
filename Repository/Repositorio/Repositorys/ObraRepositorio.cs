using DomainService.Dominio.Entidades.DTO;
using DomainService.Dominio.Interfaces.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositorio.Repositorys
{
    public class ObraRepositorio : IObraRepositorio
    {
        private IBaseRepositorio _repositorio;
        public ObraRepositorio(IBaseRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public bool CadastrarObra(ObraDTO obra)
        {
            string sql = @"INSERT INTO Obra (isbn,titulo,autor,descricao,dataPublicacao,qtdeExemplares,qtdeExemplaresLivres)
                            VALUES (@isbn,@titulo,@autor,@descricao,@dataPublicacao,@qtdeExemplares,@qtdeExemplaresLivres
                        )";
            bool retorno = false;
            //Database database = DatabaseFactory.CreateDatabase("Biblioteca");
            using (var connection = _repositorio.connection())
            {
                using (MySqlCommand comando = new MySqlCommand(sql, connection))
                {

                    comando.Parameters.AddWithValue("isbn", obra.isbn);
                    comando.Parameters.AddWithValue("titulo", obra.titulo);
                    comando.Parameters.AddWithValue("autor", obra.autor);
                    comando.Parameters.AddWithValue("descricao", obra.descricao);
                    comando.Parameters.AddWithValue("dataPublicacao", obra.dataPublicacao);
                    comando.Parameters.AddWithValue("qtdeExemplares", obra.qtdeExemplares);
                    comando.Parameters.AddWithValue("qtdeExemplaresLivres", obra.qtdeExemplaresLivres);
                    retorno = comando.ExecuteNonQuery() > 0;

                    comando.Dispose();
                }
            }

            return retorno;
        }
        public bool AlterarObra(AlterarObraDTO obra)
        {
            string sql = @"UPDATE Obra SET
                                isbn = @isbn
                                ,titulo = @titulo
                                ,autor = @autor
                                ,descricao = @descricao,
                                ,dataPublicacao = @dataPublicacao
                                ,qtdeExemplaresLivres = @qtdeExemplaresLivres
                            WHERE id = @idobra 
                        ";

            bool retorno = false;
            using (var connection = _repositorio.connection())
            {
                using (MySqlCommand comando = new MySqlCommand(sql, connection))
                {

                    comando.Parameters.AddWithValue("isbn", obra.isbn);
                    comando.Parameters.AddWithValue("titulo", obra.titulo);
                    comando.Parameters.AddWithValue("autor", obra.autor);
                    comando.Parameters.AddWithValue("descricao", obra.descricao);
                    comando.Parameters.AddWithValue("dataPublicacao", obra.dataPublicacao);
                    comando.Parameters.AddWithValue("qtdeExemplares", obra.qtdeExemplares);
                    comando.Parameters.AddWithValue("qtdeExemplaresLivres", obra.qtdeExemplaresLivres);
                    retorno = comando.ExecuteNonQuery() > 0;

                    comando.Dispose();
                }
            }

            return retorno;
        }
        public ObraDTO BuscarObra(int idobra)
        {
            string sql = @"SELECT
                            id
                            isbn 
                            ,titulo
                            ,autor
                            ,descricao
                            ,dataPublicacao
                            ,qtdeExemplares
                            ,qtdeExemplaresLivres
                            FROM Obra WHERE id = @idobra
                          ";

            ObraDTO retorno = null;

            using (var connection = _repositorio.connection())
            {
                using (MySqlCommand comando = new MySqlCommand(sql, connection))
                {

                    comando.Parameters.AddWithValue("idobra", idobra);

                    var dr = comando.ExecuteReader();
                    if (dr.Read())
                    {
                        retorno = new ObraDTO()
                        {
                            idObra = Convert.ToInt32(dr["id"]),
                            isbn = dr["isbn"].ToString(),
                            titulo = dr["titulo"].ToString(),
                            autor = dr["autor"].ToString(),
                            descricao = dr["descricao"].ToString(),
                            dataPublicacao = Convert.ToDateTime(dr["dataPublicacao"]),
                            qtdeExemplares = Convert.ToInt32(dr["qtdeExemplares"]),
                            qtdeExemplaresLivres = Convert.ToInt32(dr["qtdeExemplaresLivres"]),
                        };
                    }

                    comando.Dispose();
                }
            }

            return retorno;
        }
        public List<ObraDTO> ListarObra()
        {
            string sql = @"SELECT 
                            id
                            ,isbn 
                            ,titulo
                            ,autor
                            ,descricao
                            ,dataPublicacao
                            ,qtdeExemplares
                            ,qtdeExemplaresLivres
                            FROM Obra 
                          ";

            

            List<ObraDTO> retorno = new List<ObraDTO>();

            using (var connection = _repositorio.connection())
            {
                using (MySqlCommand comando = new MySqlCommand(sql, connection))
                {
                    var dr = comando.ExecuteReader();
                    while (dr.Read())
                    {
                        retorno.Add(new ObraDTO()
                        {
                            idObra = Convert.ToInt32(dr["id"]),
                            isbn = dr["isbn"].ToString(),
                            titulo = dr["titulo"].ToString(),
                            autor = dr["autor"].ToString(),
                            descricao = dr["descricao"].ToString(),
                            dataPublicacao = Convert.ToDateTime(dr["dataPublicacao"]),
                            qtdeExemplares = Convert.ToInt32(dr["qtdeExemplares"]),
                            qtdeExemplaresLivres = Convert.ToInt32(dr["qtdeExemplaresLivres"]),
                        });
                    }

                    comando.Dispose();
                }
            }

            return retorno;
        }
    }
}
