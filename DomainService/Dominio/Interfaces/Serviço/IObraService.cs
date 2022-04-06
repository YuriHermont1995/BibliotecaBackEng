using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Dominio.Entidades.DTO;

namespace DomainService.Dominio.Interfaces.Serviço
{
    public interface IObraService
    {
        bool AlterarObra(ObraDTO cliente);
        bool InserirObra(ObraDTO cliente);
        ObraDTO BuscarObra(int idObra);
        List<ObraDTO> ListarObra();
        bool DesativarObra(int idObra);
        
    }
}
