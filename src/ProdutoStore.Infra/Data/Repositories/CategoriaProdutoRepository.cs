using ProdutoStore.Business.Interfaces.Repositories;
using ProdutoStore.Business.Models;
using ProdutoStore.Infra.Data.Context;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ProdutoStore.Infra.Data.Repositories
{
    public class CategoriaProdutoRepository : Repository<CategoriaProduto>, ICategoriaProdutoRepository
    {
        #region Construtores Públicos

        public CategoriaProdutoRepository(ProdutoStoreContext contexto) : base(contexto)
        {

        }

        #endregion Construtores Públicos

        #region Métodos Públicos

        public async Task<CategoriaProduto> ObterCategoriaEProdutos(int id)
        {
            return await Contexto.CategoriaProdutos.AsNoTracking()
                                                  .Include(categoriaProduto => categoriaProduto.Produtos)
                                                  .FirstOrDefaultAsync(categoriaProduto => categoriaProduto.Id == id);
        }

        #endregion Métodos Públicos
    }
}
