using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Dominio.Entidades.DTO;

namespace DomainService.Dominio.Interfaces.Repository
{
    public interface IEmprestimoRepositorio
    {
        bool ListarEmprestimos();
        bool RealizarEmprestimo(ObraDTO obra, ClienteDTO cliente);
    }
}
