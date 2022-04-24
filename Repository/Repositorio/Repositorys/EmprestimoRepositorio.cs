using DomainService.Dominio.Interfaces.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositorio.Repositorys
{
    public class EmprestimoRepositorio : IEmprestimoRepositorio
    {
        private IBaseRepositorio _repositorio;
        public EmprestimoRepositorio(IBaseRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public bool ListarEmprestimos()
        {
            throw new NotImplementedException();
        }

        public bool RealizarEmprestimo(int idObra, int idCliente)
        {
            string sql = @"INSERT INTO Emprestimo (idObra,idCliente,dataEmprestimo,dataDevolucaoEsperada)
                            VALUES (@idObra,@idCliente,NOW(),date_add(now(),interval 7 day))
                        )";
            bool retorno = false;
            
            using (var connection = _repositorio.connection())
            {
                using (MySqlCommand comando = new MySqlCommand(sql, connection))
                {

                    comando.Parameters.AddWithValue("idObra", idObra);
                    comando.Parameters.AddWithValue("idCliente", idCliente);
                    retorno = comando.ExecuteNonQuery() > 0;

                    comando.Dispose();
                }
            }

            return retorno;
        }
    }
}
