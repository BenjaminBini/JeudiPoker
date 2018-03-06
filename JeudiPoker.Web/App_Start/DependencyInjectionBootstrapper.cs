using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using JeudiPoker.Data.Infrastructure;
using JeudiPoker.Data.Repositories;
using JeudiPoker.Service;

namespace JeudiPoker.Web
{
    /// <summary>
    /// DI configuration
    /// </summary>
    public class DependencyInjectionBootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
        }

        private static void SetAutofacContainer()
        {
            // Autofac container builder
            var builder = new ContainerBuilder();

            // Global configuration
            var config = GlobalConfiguration.Configuration;

            // Register Autofac WebApi filter provider
            builder.RegisterWebApiFilterProvider(config);

            // Register Autofac WebApi model binder provider
            builder.RegisterWebApiModelBinderProvider();

            // Register API controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register Controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // Register UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            // Register DbFactory
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // Register repositories
            builder.RegisterAssemblyTypes(typeof(GroupRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            // Register services
            builder.RegisterAssemblyTypes(typeof(GroupService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            // Build container
            var container = builder.Build();

            // Use the container to resolve dependencies for MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            // and for WebApi
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}