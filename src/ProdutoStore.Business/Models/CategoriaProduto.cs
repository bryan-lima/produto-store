using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoStore.Business.Models
{
    public class CategoriaProduto : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}
