using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProdutoStore.AppMvc.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Categoria de Produto")]
        public int CategoriaProdutoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Descrição")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [DisplayName("Perecível?")]
        public bool Perecivel { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        public CategoriaProdutoViewModel CategoriaProduto { get; set; }

        public IEnumerable<CategoriaProdutoViewModel> CategoriasProdutos { get; set; }
    }
}