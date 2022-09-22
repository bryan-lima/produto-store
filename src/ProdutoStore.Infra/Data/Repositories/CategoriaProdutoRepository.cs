using ProdutoStore.Business.Interfaces.Repositories;
using ProdutoStore.Business.Models;
using ProdutoStore.Infra.Data.Context;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProdutoStore.Infra.Data.Repositories
{
    public class CategoriaProdutoRepository : Repository<CategoriaProduto>, ICategoriaProdutoRepository
    {
        public CategoriaProdutoRepository(ProdutoStoreContext contexto) : base(contexto)
        {
            
        }

        public async Task<CategoriaProduto> ObterCategoriaEProdutos(int id)
        {
            return await Contexto.CategoriaProdutos.AsNoTracking()
                                                  .Include(categoriaProduto => categoriaProduto.Produtos)
                                                  .FirstOrDefaultAsync(categoriaProduto => categoriaProduto.Id == id);
        }
    }
}
