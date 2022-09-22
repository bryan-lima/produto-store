using ProdutoStore.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProdutoStore.Business.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        #region Métodos Públicos

        Task<Produto> ObterProdutoECategoria(int id);

        Task<IEnumerable<Produto>> ObterTodosProdutosECategoria();

        #endregion Métodos Públicos
    }
}
