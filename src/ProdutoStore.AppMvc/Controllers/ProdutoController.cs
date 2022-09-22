using AutoMapper;
using ProdutoStore.AppMvc.ViewModels;
using ProdutoStore.Business.Interfaces.Notificacoes;
using ProdutoStore.Business.Interfaces.Repositories;
using ProdutoStore.Business.Interfaces.Services;
using ProdutoStore.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProdutoStore.AppMvc.Controllers
{
    [RoutePrefix("produto")]
    public class ProdutoController : BaseController
    {
        #region Campos Privados

        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;

        #endregion Campos Privados

        #region Construtores Públicos

        public ProdutoController(ICategoriaProdutoRepository categoriaProdutoRepository,
                                 IMapper mapper,
                                 INotificador notificador,
                                 IProdutoRepository produtoRepository,
                                 IProdutoService produtoService) : base(notificador)
        {
            _categoriaProdutoRepository = categoriaProdutoRepository;
            _mapper = mapper;
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
        }

        #endregion Construtores Públicos

        #region GET

        [HttpGet]
        public async Task<ActionResult> Index()
        {

            ProdutoExibicaoViewModel _produtoExibicaoViewModel = new ProdutoExibicaoViewModel(produtos: _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterTodosProdutosECategoria()));
            await PopularCategoriasProdutos(_produtoExibicaoViewModel.ProdutoViewModel);

            return View(_produtoExibicaoViewModel);
        }

        [HttpGet]
        [Route("deletar/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            Produto _produto = await _produtoRepository.ObterPorId(id);

            if (_produto == null)
                return HttpNotFound();

            await _produtoService.Remover(_produto);

            return RedirectToAction("Index");
        }

        #endregion GET

        #region POST

        [HttpPost]
        [Route("cadastrar")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProdutoExibicaoViewModel produtoExibicaoViewModel)
        {
            if (!ModelState.IsValid)
                return View("Index", produtoExibicaoViewModel);

            produtoExibicaoViewModel.ProdutoViewModel.Ativo = true;

            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoExibicaoViewModel.ProdutoViewModel));

            if (!OperacaoValida())
                return View("Index", produtoExibicaoViewModel);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("atualizar/{id:int}")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ProdutoExibicaoViewModel produtoExibicaoViewModel)
        {
            if (!ModelState.IsValid)
                return View(produtoExibicaoViewModel);

            Produto _produto = await _produtoRepository.ObterPorId(id);

            if (_produto == null)
                return HttpNotFound();

            await _produtoService.Atualizar(_mapper.Map<Produto>(produtoExibicaoViewModel.ProdutoViewModel));

            if (!OperacaoValida())
                return View("Index", produtoExibicaoViewModel);

            return RedirectToAction("Index");
        }

        #endregion POST

        #region Métodos Privados

        private async Task<ProdutoViewModel> ObterProdutoECategoria(int id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoECategoria(id));
        }

        private async Task<ProdutoViewModel> PopularCategoriasProdutos(ProdutoViewModel produtoViewModel)
        {
            produtoViewModel.CategoriasProdutos = _mapper.Map<IEnumerable<CategoriaProdutoViewModel>>(await _categoriaProdutoRepository.ObterTodos());
            return produtoViewModel;
        }

        #endregion Métodos Privados

        #region Métodos Protegidos

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _produtoRepository?.Dispose();
                _produtoService?.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion Métodos Protegidos
    }
}
