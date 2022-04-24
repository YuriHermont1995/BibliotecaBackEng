using DomainService.Dominio.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Dominio.Interfaces
{
    public interface IClienteService
    {
        bool AlterarCliente(AlterarClienteDTO cliente);
        bool InserirCliente(ClienteDTO cliente);
        ClienteDTO BuscarCliente(int idUsuario);
        List<ClienteDTO> ListarCliente();
        bool DesativarCliente(int idCliente);
        
    }
}
