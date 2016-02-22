using LendingLibrary.DbMigrations;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using LendingLibrary.Domain;

namespace LendingLibrary
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MigrateDatabase();
        }

        private static void MigrateDatabase()
        {
            var connectionName = "LendingLibrary.Domain.LendingLibraryDbContext";
            CreateDb();
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            var migrationsRunner = new MigrationsRunner(connectionString);
            migrationsRunner.MigrateToLatest();
        }

        private static void CreateDb()
        {
            throw new System.NotImplementedException();
        }
    }
}