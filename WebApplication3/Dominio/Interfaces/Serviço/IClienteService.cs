using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Dominio.Entidades.DTO;

namespace WebApplication3.Dominio.Interfaces
{
    public interface IClienteService
    {
        bool AlterarCliente(ClienteDTO cliente);
        bool InserirCliente(ClienteDTO cliente);
        ClienteDTO BuscarCliente(int idUsuario);
        List<ClienteDTO> ListarCliente();
        bool DesativarCliente(int idCliente);
    }
}
