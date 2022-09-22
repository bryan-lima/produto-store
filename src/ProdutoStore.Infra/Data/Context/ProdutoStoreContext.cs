using ProdutoStore.Business.Models;
using ProdutoStore.Infra.Data.Mappings;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;

namespace ProdutoStore.Infra.Data.Context
{
    public class ProdutoStoreContext : DbContext
    {
        #region Construtores Públicos

        public ProdutoStoreContext() : base("ProdutoStoreConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProdutoStoreContext, Migrations.Configuration>());
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Database.CommandTimeout = 500;
            Database.Log = sql => Debug.Write(sql);
        }

        #endregion Construtores Públicos

        #region DbSets

        public DbSet<CategoriaProduto> CategoriaProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        #endregion DbSets

        #region Métodos Protegidos

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

            #region Configurações Entity

            modelBuilder.Configurations.Add(new CategoriaProdutoMap());
            modelBuilder.Configurations.Add(new ProdutoMap());

            #endregion Configurações Entity

            base.OnModelCreating(modelBuilder);
        }

        #endregion Métodos Protegidos
    }
}
