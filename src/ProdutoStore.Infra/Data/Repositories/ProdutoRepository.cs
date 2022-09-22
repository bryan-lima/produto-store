using ProdutoStore.Business.Interfaces.Repositories;
using ProdutoStore.Business.Models;
using ProdutoStore.Infra.Data.Context;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace ProdutoStore.Infra.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        #region Construtores Públicos

        public ProdutoRepository(ProdutoStoreContext contexto) : base(contexto)
        {

        }

        #endregion Construtores Públicos

        #region Métodos Públicos
        public async Task<Produto> ObterProdutoECategoria(int id)
        {
            return await Contexto.Produtos.AsNoTracking()
                                          .Include(produto => produto.CategoriaProduto)
                                          .FirstOrDefaultAsync(produto => produto.Ativo
                                                                       && produto.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterTodosProdutosECategoria()
        {
            return await Contexto.Produtos.AsNoTracking()
                                          .Include(produto => produto.CategoriaProduto)
                                          .Where(produto => produto.Ativo)
                                          .OrderBy(produto => produto.Id)
                                          .ToListAsync();
        }

        #endregion Métodos Públicos
    }
}
