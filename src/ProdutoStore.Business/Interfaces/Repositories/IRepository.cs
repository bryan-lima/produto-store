using ProdutoStore.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProdutoStore.Business.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        
        #region Métodos Públicos

        Task Adicionar(TEntity entidade);

        Task<TEntity> ObterPorId(int id);

        Task<List<TEntity>> ObterTodos();

        Task Atualizar(TEntity entidade);

        Task Remover(TEntity entidade, bool forcePhysicalDelete = false);

        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicado);

        Task<int> SaveChanges();

        #endregion Métodos Públicos
    }
}
