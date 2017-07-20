namespace BankSystem_v2.Controllers
{
    using System.Web.Mvc;
    using DataAccess.Repository;

    public abstract class BaseController : Controller
    {
        protected BankSystemDbContext Db { get; set; } = new BankSystemDbContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}