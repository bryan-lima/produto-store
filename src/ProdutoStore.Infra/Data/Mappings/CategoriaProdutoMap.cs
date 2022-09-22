using ProdutoStore.Business.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace ProdutoStore.Infra.Data.Mappings
{
    public class CategoriaProdutoMap : EntityTypeConfiguration<CategoriaProduto>
    {
        public CategoriaProdutoMap()
        {
            Property(categoriaProduto => categoriaProduto.Nome)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                     new IndexAnnotation(new IndexAttribute("IX_CategoriaProduto_Nome_Unique", 1)
                                     {
                                         IsUnique = true
                                     }));

            Property(categoriaProduto => categoriaProduto.Descricao)
                .IsRequired()
                .HasMaxLength(250);

            ToTable("tblCategoriaProduto");
        }
    }
}
