using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoStore.Business.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
    }
}
