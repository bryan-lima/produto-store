using AutoMapper;
using ProdutoStore.AppMvc.ViewModels;
using ProdutoStore.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ProdutoStore.AppMvc.App_Start
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            IEnumerable<Type> profiles = Assembly.GetExecutingAssembly()
                                                 .GetTypes()
                                                 .Where(type => typeof(Profile).IsAssignableFrom(type));

            return new MapperConfiguration(configuration =>
            {
                foreach (Type profile in profiles)
                    configuration.AddProfile(Activator.CreateInstance(profile) as Profile);
            });
        }
    }

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Produto, ProdutoViewModel>()
                .ReverseMap();

            CreateMap<CategoriaProduto, CategoriaProdutoViewModel>()
                .ReverseMap();
        }
    }
}