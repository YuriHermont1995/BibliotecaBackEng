using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Dominio.Entidades.DTO
{
    public class ObraDTO
    {
        public int idObra { get; set; }
        public string isbn { get; set; }
        public string titulo { get; set; }
        public string autor { get; set; }
        public string descricao { get; set; }
        public DateTime dataPublicacao { get; set; }
        public int qtdeExemplares { get; set; }
        public int qtdeExemplaresLivres { get; set; }
    }
}
