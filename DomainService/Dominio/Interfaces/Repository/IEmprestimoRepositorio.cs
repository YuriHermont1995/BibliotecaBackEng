﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Dominio.Interfaces.Repository
{
    public interface IEmprestimoRepositorio
    {
        bool ListarEmprestimos();
        bool RealizarEmprestimo(int idObra, int idCliente);
    }
}
