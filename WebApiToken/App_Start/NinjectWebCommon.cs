[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebApiToken.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WebApiToken.App_Start.NinjectWebCommon), "Stop")]

namespace WebApiToken.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using WebApiToken.Abstract;
    using WebApiToken.Concrete;
    using WebApiToken.Models;
    using Moq;
    using System.Collections.Generic;

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
            Department d1 = new Department { Id = 1, Name = "Cyberacademy" };
            Department d2 = new Department { Id = 2, Name = "Security" };

            Mock<IStudentRepository> mock = new Mock<IStudentRepository>();
            mock.Setup(m => m.GetStudents()).Returns(new List<Student>
            {
                 new Student{ Name = "Chuks", MatricNo = "01", Id = 1, Department = d1 },
                 new Student{ Name = "Emmanuel", MatricNo = "02", Id = 2, Department = d2 },
                 new Student{ Name = "Muna", MatricNo = "03", Id = 3, Department = d1 },
                 new Student{ Name = "Winnie", MatricNo = "04", Id = 4, Department = d2 },
                 new Student{ Name = "Lola", MatricNo = "05", Id = 5, Department = d1 }

            });
            kernel.Bind<IStudentRepository>().ToConstant(mock.Object);

            //kernel.Bind<IStudentRepository>().To<StudentRepository>();
        }        
    }
}
