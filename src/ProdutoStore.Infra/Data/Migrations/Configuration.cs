using ProdutoStore.Business.Models;
using ProdutoStore.Infra.Data.Context;
using System.Data.Entity.Migrations;

namespace ProdutoStore.Infra.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ProdutoStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProdutoStoreContext contexto)
        {
            #region CategoriaProduto

            contexto.CategoriaProdutos.AddOrUpdate(
                new CategoriaProduto
                {
                    Id = 1,
                    Nome = "Eletrônico",
                    Descricao = "Eletrodomésticos",
                    Ativo = true
                },
                new CategoriaProduto
                {
                    Id = 2,
                    Nome = "Informática",
                    Descricao = "Produtos para Informática",
                    Ativo = true
                },
                new CategoriaProduto
                {
                    Id = 3,
                    Nome = "Celulares",
                    Descricao = "Aparelhos e acessórios",
                    Ativo = true
                },
                new CategoriaProduto
                {
                    Id = 4,
                    Nome = "Moda",
                    Descricao = "Artigos para vestuário em geral",
                    Ativo = true
                },
                new CategoriaProduto
                {
                    Id = 5,
                    Nome = "Livros",
                    Descricao = "Livros",
                    Ativo = true
                });

            #endregion CategoriaProduto
        }
    }
}
