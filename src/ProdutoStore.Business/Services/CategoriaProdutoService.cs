using ProdutoStore.Business.Interfaces.Notificacoes;
using ProdutoStore.Business.Interfaces.Repositories;
using ProdutoStore.Business.Interfaces.Services;
using ProdutoStore.Business.Models;
using ProdutoStore.Business.Models.Validations;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutoStore.Business.Services
{
    public class CategoriaProdutoService : BaseService, ICategoriaProdutoService
    {
        #region Campos Privados

        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;

        #endregion Campos Privados

        #region Construtores Públicos

        public CategoriaProdutoService(ICategoriaProdutoRepository categoriaProdutoRepository,
                                       INotificador notificador) : base(notificador)
        {
            _categoriaProdutoRepository = categoriaProdutoRepository;
        }

        #endregion Construtores Públicos

        #region Métodos Públicos

        public async Task Adicionar(CategoriaProduto categoriaProduto)
        {
            if (!ExecutarValidacao(new CategoriaProdutoValidation(), categoriaProduto))
                return;

            await _categoriaProdutoRepository.Adicionar(categoriaProduto);
        }

        public async Task Atualizar(CategoriaProduto categoriaProduto)
        {
            if (!ExecutarValidacao(new CategoriaProdutoValidation(), categoriaProduto))
                return;

            await _categoriaProdutoRepository.Atualizar(categoriaProduto);
        }

        public async Task Remover(int id)
        {
            CategoriaProduto _categoriaProduto = await _categoriaProdutoRepository.ObterCategoriaEProdutos(id);

            if (_categoriaProduto.Produtos.Any())
            {
                Notificar("A cateoria possui produtos associados!");
                return;
            }

            await _categoriaProdutoRepository.Remover(_categoriaProduto);
        }

        public void Dispose()
        {
            _categoriaProdutoRepository?.Dispose();
        }

        #endregion Métodos Públicos
    }
}
