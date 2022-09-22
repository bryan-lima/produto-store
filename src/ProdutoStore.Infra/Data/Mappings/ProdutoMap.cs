using ProdutoStore.Business.Models;
using System.Data.Entity.ModelConfiguration;

namespace ProdutoStore.Infra.Data.Mappings
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            Property(produto => produto.Nome)
                .IsRequired()
                .HasMaxLength(250);

            Property(produto => produto.Descricao)
                .IsRequired()
                .HasMaxLength(250);

            Property(produto => produto.CategoriaProdutoId)
                .HasColumnName("CategoriaID");

            HasRequired(produto => produto.CategoriaProduto)
                .WithMany(categoriaProduto => categoriaProduto.Produtos)
                .HasForeignKey(c => c.CategoriaProdutoId);

            ToTable("tblProduto");
        }
    }
}
