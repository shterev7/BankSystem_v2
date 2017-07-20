using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DataAccess.Repository;

namespace BankSystem_v2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BankSystemDbContext context = new BankSystemDbContext();
            context.Database.CreateIfNotExists();
        }
    }
}
