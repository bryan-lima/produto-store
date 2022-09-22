using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProdutoStore.AppMvc.Startup))]
namespace ProdutoStore.AppMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
