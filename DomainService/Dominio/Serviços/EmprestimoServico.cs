using DomainService.Dominio.Entidades.DTO;
using DomainService.Dominio.Interfaces.Repository;
using DomainService.Dominio.Interfaces.Serviço;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Dominio.Interfaces.Repository;

namespace DomainService.Dominio.Serviços
{
    public class EmprestimoServico : IEmprestimoService
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IObraRepositorio _obraRepositorio;
        private readonly IEmprestimoRepositorio _empretimorepositorio;
        public EmprestimoServico(IClienteRepositorio clienteRepositorio,IObraRepositorio obraRepositorio, IEmprestimoRepositorio empretimorepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
            _obraRepositorio = obraRepositorio;
            _empretimorepositorio = empretimorepositorio;
        }

        public bool AlterarEmprestimo(EmprestimoDTO emprestimo)
        {
            throw new NotImplementedException();
        }

        public EmprestimoDTO BuscarEmprestimo(int idEmprestimo)
        {
            throw new NotImplementedException();
        }

        public bool InserirEmprestimo(int idCliente, int idObra)
        {
            bool exemplarLivre = _obraRepositorio.BuscarObra(idObra).qtdeExemplaresLivres > 0;
            
            if (exemplarLivre)
            {
                bool possuiMulta = _clienteRepositorio.BuscarCliente(idCliente).possuiMulta;
                if (!possuiMulta)
                {
                    return _empretimorepositorio.RealizarEmprestimo(idObra, idCliente);
                }
                return false;
            }
            return false;
        }

        public List<EmprestimoDTO> ListarEmprestimo()
        {
            throw new NotImplementedException();
        }
    }
}
