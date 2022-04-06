using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Dominio.Entidades.DTO;
using WebApplication3.Dominio.Interfaces;
using WebApplication3.Dominio.Interfaces.Repository;
using WebApplication3.Repositorio.Repositorys;

namespace WebApplication3.Dominio.Serviços
{
    public class ClienteServico : IClienteService
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteServico(ClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public bool AlterarCliente(ClienteDTO cliente)
        {
            return _clienteRepositorio.AlterarCliente(cliente);
        }

        public bool InserirCliente(ClienteDTO cliente)
        {
            return _clienteRepositorio.CadastrarCliente(cliente);
        }
        public ClienteDTO BuscarCliente(int idUsuario)
        {
            return _clienteRepositorio.BuscarCliente(idUsuario);
        }
        public List<ClienteDTO> ListarCliente()
        {
            return _clienteRepositorio.ListarCliente();
        }
        public bool DesativarCliente(int idCliente)
        {
            return _clienteRepositorio.ExcluirCliente(idCliente);
        }

       
    }
}
