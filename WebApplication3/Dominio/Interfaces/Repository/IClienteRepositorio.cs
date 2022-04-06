using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Dominio.Entidades.DTO;

namespace WebApplication3.Dominio.Interfaces.Repository
{
    public interface IClienteRepositorio
    {
        bool CadastrarCliente(ClienteDTO usuario);
        bool AlterarCliente(ClienteDTO usuario);
        ClienteDTO BuscarCliente(int idUsuario);
        List<ClienteDTO> ListarCliente();
        bool ExcluirCliente(int idUsuario);

    }
}
