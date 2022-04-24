using DomainService.Dominio.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Dominio.Interfaces.Repository
{
    public interface IClienteRepositorio
    {
        bool CadastrarCliente(ClienteDTO usuario);
        bool AlterarCliente(AlterarClienteDTO usuario);
        ClienteDTO BuscarCliente(int idUsuario);
        List<ClienteDTO> ListarCliente();
        bool ExcluirCliente(int idUsuario);

    }
}
