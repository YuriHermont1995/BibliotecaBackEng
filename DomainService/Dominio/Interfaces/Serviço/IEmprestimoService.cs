using DomainService.Dominio.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Dominio.Entidades.DTO;

namespace DomainService.Dominio.Interfaces.Serviço
{
    public interface IEmprestimoService
    {
        bool AlterarEmprestimo(EmprestimoDTO emprestimo);
        bool InserirEmprestimo(ClienteDTO cliente, ObraDTO obra);
        EmprestimoDTO BuscarEmprestimo(int idEmprestimo);
        List<EmprestimoDTO> ListarEmprestimo();
        
    }
}
