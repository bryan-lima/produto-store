using ProdutoStore.Business.Models;
using System;
using System.Threading.Tasks;

namespace ProdutoStore.Business.Interfaces.Services
{
    public interface IProdutoService : IDisposable
    {
        #region Métodos Públicos

        Task Adicionar(Produto produto);

        Task Atualizar(Produto produto);

        Task Remover(Produto produto);

        #endregion Métodos Públicos
    }
}
