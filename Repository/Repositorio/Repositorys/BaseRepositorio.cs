using DomainService.Dominio.Interfaces.Repository;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositorio.Repositorys
{
    public class BaseRepositorio : IBaseRepositorio
    {
        private MySqlConnection _conn;
        private MySqlConnectionStringBuilder _stringConn;
        public BaseRepositorio()
        {
            //new MySqlConnection("Server=localhost; port= 3306; Database=Biblioteca; UserId=adminBibliote; Password=admin;");
            _stringConn = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "biblioteca",
                UserID = "adminBibliote",
                Password = "admin",
                Port = 3306,
                SslMode = MySqlSslMode.Required,
            };
        }
        public MySqlConnection connection() 
        {
            _conn = new MySqlConnection(_stringConn.ConnectionString);
            _conn.Open();
                       
            return _conn;
            
        }
        
            
    }
}
