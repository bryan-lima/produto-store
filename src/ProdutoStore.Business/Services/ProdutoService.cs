using ProdutoStore.Business.Interfaces.Repositories;
using ProdutoStore.Business.Interfaces.Services;
using ProdutoStore.Business.Models;
using ProdutoStore.Business.Models.Validations;
using System.Threading.Tasks;

namespace ProdutoStore.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        #region Campos Privados

        private readonly IProdutoRepository _produtoRepository;

        #endregion Campos Privados

        #region Construtores Públicos

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        #endregion Construtores Públicos

        #region Métodos Públicos

        public async Task Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto))
                return;

            await _produtoRepository.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto))
                return;

            await _produtoRepository.Atualizar(produto);
        }

        public async Task Remover(int id)
        {
            await _produtoRepository.Remover(id);
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }

        #endregion Métodos Públicos
    }
}
