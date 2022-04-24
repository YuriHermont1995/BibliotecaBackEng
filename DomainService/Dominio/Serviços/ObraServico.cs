using DomainService.Dominio.Entidades.DTO;
using DomainService.Dominio.Interfaces.Repository;
using DomainService.Dominio.Interfaces.Serviço;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Dominio.Serviços
{
    public class ObraServico : IObraService
    {
        private readonly IObraRepositorio _obraRepositorio;
        private readonly IEmprestimoService _empretimoService;
        public ObraServico(IObraRepositorio obraRepositorio, IEmprestimoService empretimoService)
        {
            _obraRepositorio = obraRepositorio;
            _empretimoService = empretimoService;
        }
        public bool AlterarObra(AlterarObraDTO obra)
        {
            return _obraRepositorio.AlterarObra(obra);
        }

        public bool InserirObra(ObraDTO Obra)
        {
            return _obraRepositorio.CadastrarObra(Obra);
        }
        public ObraDTO BuscarObra(int idUsuario)
        {
            return _obraRepositorio.BuscarObra(idUsuario);
        }
        public List<ObraDTO> ListarObra()
        {
            return _obraRepositorio.ListarObra();
        }
        //public bool DesativarObra(int idObra)
        //{
        //    return _obraRepositorio.ExcluirObra(idObra);
        //}

        public bool RealizarEmprestimo(int idObra, int idCliente)
        {
            return _empretimoService.InserirEmprestimo(idObra, idCliente);
        }
    }
}
