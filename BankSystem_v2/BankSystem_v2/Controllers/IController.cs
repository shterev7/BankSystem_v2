using System.Web.Mvc;

namespace BankSystem_v2.Controllers
{
    public interface IController
    {
        ActionResult Index();
        ActionResult Create();
        ActionResult Details(string id);
        ActionResult Edit(string id);
        ActionResult Delete(string id);
        ActionResult DeleteConfirmed(string id);
    }
}