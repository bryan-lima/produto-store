using ProdutoStore.Business.Models;
using System.Threading.Tasks;

namespace ProdutoStore.Business.Interfaces.Repositories
{
    public interface ICategoriaProdutoRepository : IRepository<CategoriaProduto>
    {
        #region Métodos Públicos

        Task<CategoriaProduto> ObterCategoriaEProdutos(int id);

        #endregion Métodos Públicos
    }
}
