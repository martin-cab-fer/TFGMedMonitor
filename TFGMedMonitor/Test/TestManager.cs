using Ninject;
using System;
using System.Collections.Generic;
using Model.UserProfileDao;
using Model.UserService;
using Model.HealthDao;
using Model.AdminDao;
using Model.AdminService;
using Model.HealthService;
using System.Configuration;
using System.Data.Entity;

namespace Test
{
    public class TestManager
    {
        /// <summary>
        /// Configures and populates the Ninject kernel
        /// </summary>
        /// <returns>The NInject kernel</returns>
        public static IKernel ConfigureNInjectKernel()
        {
            NinjectSettings settings = new NinjectSettings() { LoadExtensions = true };

            IKernel kernel = new StandardKernel(settings);
            
            kernel.Bind<IUserProfileDao>().
                To<UserProfileDaoEntityFramework>();

            kernel.Bind<IUserService>().
                To<UserService>();

            kernel.Bind<IChatMessageDao>().
               To<ChatMessageDaoEntityFramework>();

            kernel.Bind<IMedicineDao>().
               To<MedicineDaoEntityFramework>();

            kernel.Bind<IPatientDao>().
               To<PatientDaoEntityFramework>();

            kernel.Bind<IAdminService>().
                To<AdminService>();

            kernel.Bind<IAnalyticDao>().
               To<AnalyticDaoEntityFramework>();

            kernel.Bind<IDoseDao>().
               To<DoseDaoEntityFramework>();

            kernel.Bind<IPrescriptionDao>().
               To<PrescriptionDaoEntityFramework>();

            kernel.Bind<IHealthService>().
                To<HealthService>();

            string connectionString =
                ConfigurationManager.ConnectionStrings["medmonitorEntities"].ConnectionString;

            kernel.Bind<DbContext>().
                ToSelf().
                InSingletonScope().
                WithConstructorArgument("nameOrConnectionString", connectionString);

            return kernel;
        }

        /// <summary>
        /// Configures the Ninject kernel from an external module file.
        /// </summary>
        /// <param name="moduleFilename">The module filename.</param>
        /// <returns>The NInject kernel</returns>
        public static IKernel ConfigureNInjectKernel(string moduleFilename)
        {
            NinjectSettings settings = new NinjectSettings() { LoadExtensions = true };
            IKernel kernel = new StandardKernel(settings);

            kernel.Load(moduleFilename);

            return kernel;
        }

        public static void ClearNInjectKernel(IKernel kernel)
        {
            kernel.Dispose();
        }

    }
}
