using DomainService.Dominio.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Dominio.Interfaces.Serviço
{
    public interface IObraService
    {
        bool AlterarObra(AlterarObraDTO cliente);
        bool InserirObra(ObraDTO cliente);
        ObraDTO BuscarObra(int idObra);
        List<ObraDTO> ListarObra();
        //bool DesativarObra(int idObra);
        
    }
}
