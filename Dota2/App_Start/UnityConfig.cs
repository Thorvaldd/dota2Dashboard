using System;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using WebApiRepository.Implementations.RepositoryRequests;
using WebApiRepository.Interfaces;
using WebApiRepository.UnitOfWork;

namespace Dota2.App_Start
{
    public  class UnityConfig
    {
        #region UnityContainer
        private static readonly Lazy<IUnityContainer>  Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);

            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return Container.Value;
        }

        #endregion


        public static void RegisterTypes(IUnityContainer container)
        {

            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IDota2HeroesService, Dota2HeroesService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}