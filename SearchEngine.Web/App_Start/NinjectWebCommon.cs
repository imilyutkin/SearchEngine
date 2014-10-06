using System.Configuration;
using MilyutkinI.Repository.Contracts;
using Neo4jClient;
using SearchEngine.DomainModels.Context;
using SearchEngine.Repositories.Contracts;
using SearchEngine.Repositories.Impl;
using SearchEngine.Repositories.neo4j.Contracts;
using SearchEngine.Repositories.neo4j.Impl;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SearchEngine.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SearchEngine.Web.App_Start.NinjectWebCommon), "Stop")]

namespace SearchEngine.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ISourceContext>().To<SearchEngineSourceContext>();
            kernel.Bind<IUrlRepository>().To<UrlRepository>();
            kernel.Bind<IGraphClient>().ToMethod(context =>
            {
                var client =
                    new GraphClient(new Uri(ConfigurationManager.ConnectionStrings["neo4jConnectionString"].ConnectionString));
                client.Connect();
                return client;
            }).InSingletonScope();
            kernel.Bind<ILinkNodeRepository>().To<LinkNodeRepository>();
        }        
    }
}
