using DomainService.Dominio.Interfaces.Serviço;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Dominio.Entidades.DTO;
using WebApplication3.Dominio.Interfaces;
using WebApplication3.Dominio.Interfaces.Repository;


namespace WebApplication3.Dominio.Serviços
{
    public class ClienteServico : IClienteService
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IEmprestimoService _empretimoService;
        public ClienteServico(IClienteRepositorio clienteRepositorio, IEmprestimoService empretimoService)
        {
            _clienteRepositorio = clienteRepositorio;
            _empretimoService = empretimoService;
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

        public bool RealizarEmprestimo(ClienteDTO cliente, ObraDTO obra)
        {
            return _empretimoService.InserirEmprestimo(cliente, obra);
        }
    }
}
