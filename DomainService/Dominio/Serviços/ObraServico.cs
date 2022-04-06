using DomainService.Dominio.Interfaces.Serviço;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Dominio.Entidades.DTO;

namespace DomainService.Dominio.Serviços
{
    public class ObraServico : IObraService
    {
        public bool AlterarObra(ObraDTO cliente)
        {
            throw new NotImplementedException();
        }

        
        public bool DesativarObra(int idObra)
        {
            throw new NotImplementedException();
        }

        public bool InserirObra(ObraDTO cliente)
        {
            throw new NotImplementedException();
        }

        public bool ListarEmprestimos()
        {
            throw new NotImplementedException();
        }

        ObraDTO IObraService.BuscarObra(int idObra)
        {
            throw new NotImplementedException();
        }

        List<ObraDTO> IObraService.ListarObra()
        {
            throw new NotImplementedException();
        }
    }
}
