using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoStore.Business.Models
{
    public class Produto : Entity
    {
        public int CategoriaProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Perecivel { get; set; }
        public bool Ativo { get; set; }

        public CategoriaProduto CategoriaProduto { get; set; }
    }
}
