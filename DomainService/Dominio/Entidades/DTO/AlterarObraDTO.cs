using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Dominio.Entidades.DTO
{
    public class AlterarObraDTO
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
