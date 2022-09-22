using ProdutoStore.Business.Interfaces.Repositories;
using ProdutoStore.Business.Models;
using ProdutoStore.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProdutoStore.Infra.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ProdutoStoreContext Contexto;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(ProdutoStoreContext contexto)
        {
            Contexto = contexto;
            DbSet = Contexto.Set<TEntity>();
        }

        public virtual async Task<TEntity> ObterPorId(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicado)
        {
            return await DbSet.AsNoTracking()
                              .Where(predicado)
                              .ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entidade)
        {
            DbSet.Add(entidade);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entidade)
        {
            Contexto.Entry(entidade).State = EntityState.Modified;
            await SaveChanges();
        }

        public virtual async Task Remover(TEntity entidade, bool forcePhysicalDelete = false)
        {
            DbEntityEntry entry = Contexto.Entry(entidade);
            entry.Property("Ativo").CurrentValue = false;

            DbSet.Attach(entidade);

            entry.State = EntityState.Modified;

            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Contexto.SaveChangesAsync();
        }

        public void Dispose()
        {
            Contexto?.Dispose();
        }
    }
}
