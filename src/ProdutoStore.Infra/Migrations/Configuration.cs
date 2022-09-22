using ProdutoStore.Infra.Data.Context;
using System.Data.Entity.Migrations;

namespace ProdutoStore.Infra.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ProdutoStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProdutoStoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
