using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Dominio.Entidades.DTO
{
    public class ClienteDTO
    {
        public int idUsuario { get; set; }
        public string CPF { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string telefone{ get; set; }
        public DateTime dataNascimento{ get; set; }
        public bool possuiMulta { get; set; }
        public int qtdeEmprestimosAtivos { get; set; }

    }
}
