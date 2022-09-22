using ProdutoStore.Business.Models;
using ProdutoStore.Infra.Data.Mappings;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;

namespace ProdutoStore.Infra.Data.Context
{
    public class ProdutoStoreContext : DbContext
    {
        public ProdutoStoreContext() : base("ProdutoStoreConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Database.CommandTimeout = 500;
            Database.Log = sql => Debug.Write(sql);
        }

        public DbSet<CategoriaProduto> CategoriaProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Configurações Globais

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                        .Configure(property => property.HasColumnType("varchar")
                                                       .HasMaxLength(100));

            #endregion Configurações Globais

            #region EntityConfig

            modelBuilder.Configurations.Add(new CategoriaProdutoMap());
            modelBuilder.Configurations.Add(new ProdutoMap());

            #endregion EntityConfig

            base.OnModelCreating(modelBuilder);
        }
    }
}
