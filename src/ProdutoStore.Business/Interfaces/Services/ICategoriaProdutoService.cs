using ProdutoStore.Business.Models;
using System;
using System.Threading.Tasks;

namespace ProdutoStore.Business.Interfaces.Services
{
    public interface ICategoriaProdutoService : IDisposable
    {
        #region Métodos Públicos

        Task Adicionar(CategoriaProduto categoriaProduto);

        Task Atualizar(CategoriaProduto categoriaProduto);

        Task Remover(int id);

        #endregion Métodos Públicos
    }
}
