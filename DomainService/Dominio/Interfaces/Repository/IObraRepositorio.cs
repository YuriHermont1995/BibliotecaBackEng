using DomainService.Dominio.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Dominio.Interfaces.Repository
{
    public interface IObraRepositorio 
    {
        bool CadastrarObra(ObraDTO obra);
        bool AlterarObra(AlterarObraDTO obra);
        ObraDTO BuscarObra(int idobra);
        List<ObraDTO> ListarObra();
        //bool ExcluirObra(int idobra);
    }
}
