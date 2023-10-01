using System;
using System.Web;
using CorePersistence.Repository;
using CorePersistence.Responses;
using MediatR;
using MediatR.Ninject;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using PasswordManager.Controllers;
using PasswordManager.Domain.Repositories.CategoryRepositories;
using PasswordManager.Domain.Repositories.UserAccountsRespositories;
using PasswordManager.Domain.Repositories.UserNotesRepositories;
using PasswordManager.Domain.Services.CategoryServices;
using PasswordManager.Domain.Services.UserAccountServices;
using PasswordManager.Domain.Services.UserNotesServices;
using PasswordManager.Models;
using PasswordManager.Tools;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PasswordManager.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(PasswordManager.NinjectWebCommon), "Stop")]

namespace PasswordManager
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
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
            kernel.Bind<IPasswordGenerator>().To<PasswordGenerator>();
            kernel.Bind<IRepository<Entity>>().To<Repository<Entity, Entities>>();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<IUserAccountRepository>().To<UserAccountRepository>();
            kernel.Bind<IUserAccountService>().To<UserAccountService>();
            kernel.Bind<IUserNoteRepository>().To<UserNoteRepository>();
            kernel.Bind<IUserNoteService>().To<UserNoteService>();
        }
    }
}