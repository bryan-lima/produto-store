using ProdutoStore.Business.Interfaces.Notificacoes;
using ProdutoStore.Business.Interfaces.Repositories;
using ProdutoStore.Business.Interfaces.Services;
using ProdutoStore.Business.Notificacoes;
using ProdutoStore.Business.Services;
using ProdutoStore.Infra.Data.Context;
using ProdutoStore.Infra.Data.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace ProdutoStore.AppMvc.App_Start
{
    public class DependencyInjectionConfig
    {
        public static void RegisterDIContainer()
        {
            Container _container = new Container();
            _container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(_container);

            _container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            _container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(_container));
        }

        private static void InitializeContainer(Container container)
        {
            #region Contexts

            container.Register<ProdutoStoreContext>(Lifestyle.Scoped);

            #endregion Contexts

            #region Notificacoes

            container.Register<INotificador, Notificador>(Lifestyle.Scoped);

            #endregion Notificacoes

            #region Services

            container.Register<ICategoriaProdutoRepository, CategoriaProdutoRepository>(Lifestyle.Scoped);
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);

            #endregion Services

            #region Repositories

            container.Register<ICategoriaProdutoService, CategoriaProdutoService>(Lifestyle.Scoped);
            container.Register<IProdutoService, ProdutoService>(Lifestyle.Scoped);

            #endregion Repositories

            container.RegisterSingleton(() => AutoMapperConfig.GetMapperConfiguration()
                                                              .CreateMapper(container.GetInstance));
        }
    }
}