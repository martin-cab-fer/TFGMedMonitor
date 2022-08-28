using Es.Udc.DotNet.ModelUtil.IoC;
using Model.AdminDao;
using Model.AdminService;
using Model.HealthDao;
using Model.HealthService;
using Model.UserProfileDao;
using Model.UserService;
using Ninject;
using System.Configuration;
using System.Data.Entity;

namespace Web.HTTP.Util.IoC
{
    internal class IoCManagerNinject : IIoCManager
    {
        private static IKernel kernel;
        private static NinjectSettings settings;

        public void Configure()
        {
            settings = new NinjectSettings() { LoadExtensions = true };
            kernel = new StandardKernel(settings);

            /* UserProfileDao */
            kernel.Bind<IUserProfileDao>().
                To<UserProfileDaoEntityFramework>();

            /* UserService */
            kernel.Bind<IUserService>().
                To<UserService>();

            /* ChatMessageDao */
            kernel.Bind<IChatMessageDao>().
               To<ChatMessageDaoEntityFramework>();

            /* MedicineDao */
            kernel.Bind<IMedicineDao>().
               To<MedicineDaoEntityFramework>();

            /* PatientDao */
            kernel.Bind<IPatientDao>().
               To<PatientDaoEntityFramework>();

            /* AdminService */
            kernel.Bind<IAdminService>().
                To<AdminService>();

            /* AnalyticDao */
            kernel.Bind<IAnalyticDao>().
               To<AnalyticDaoEntityFramework>();

            /* DoseDao */
            kernel.Bind<IDoseDao>().
               To<DoseDaoEntityFramework>();

            /* PrescriptionDao */
            kernel.Bind<IPrescriptionDao>().
               To<PrescriptionDaoEntityFramework>();

            /* HealthService */
            kernel.Bind<IHealthService>().
                To<HealthService>();

            /* DbContext */
            string connectionString =
                ConfigurationManager.ConnectionStrings["medmonitorEntities"].ConnectionString;

            kernel.Bind<DbContext>().
                ToSelf().
                InSingletonScope().
                WithConstructorArgument("nameOrConnectionString", connectionString);
        }

        public T Resolve<T>()
        {
            return kernel.Get<T>();
        }
    }
}