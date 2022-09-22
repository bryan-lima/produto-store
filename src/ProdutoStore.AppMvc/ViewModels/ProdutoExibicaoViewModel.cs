using System.Collections.Generic;

namespace ProdutoStore.AppMvc.ViewModels
{
    public class ProdutoExibicaoViewModel
    {
        public ProdutoExibicaoViewModel()
        {

        }

        public ProdutoExibicaoViewModel(IEnumerable<ProdutoViewModel> produtos)
        {
            Produtos = produtos;
            ProdutoViewModel = new ProdutoViewModel();
        }

        public ProdutoExibicaoViewModel(ProdutoViewModel produtoViewModel, IEnumerable<ProdutoViewModel> produtos)
        {
            ProdutoViewModel = produtoViewModel;
            Produtos = produtos;
        }

        public ProdutoViewModel ProdutoViewModel { get; set; }
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}