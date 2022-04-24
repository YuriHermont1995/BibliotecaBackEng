using DomainService.Dominio.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Dominio.Interfaces.Serviço
{
    public interface IEmprestimoService
    {
        bool AlterarEmprestimo(EmprestimoDTO emprestimo);
        bool InserirEmprestimo(int idCliente, int idObra);
        EmprestimoDTO BuscarEmprestimo(int idEmprestimo);
        List<EmprestimoDTO> ListarEmprestimo();
        
    }
}
