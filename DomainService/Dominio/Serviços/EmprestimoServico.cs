using DomainService.Dominio.Entidades.DTO;
using DomainService.Dominio.Interfaces.Serviço;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Dominio.Entidades.DTO;

namespace DomainService.Dominio.Serviços
{
    public class EmprestimoServico : IEmprestimoService
    {
        public bool AlterarEmprestimo(EmprestimoDTO emprestimo)
        {
            throw new NotImplementedException();
        }

        public EmprestimoDTO BuscarEmprestimo(int idEmprestimo)
        {
            throw new NotImplementedException();
        }

        public bool InserirEmprestimo(ClienteDTO cliente, ObraDTO obra)
        {
            throw new NotImplementedException();
        }

        public List<EmprestimoDTO> ListarEmprestimo()
        {
            throw new NotImplementedException();
        }
    }
}
