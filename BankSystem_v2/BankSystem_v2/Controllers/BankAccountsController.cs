namespace BankSystem_v2.Controllers
{
    using System.Net;
    using System.Linq;
    using System.Web.Mvc;
    using DataAccess.Entity;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity;

    public class BankAccountsController : BaseController, IController
    {
        // GET: BankAccounts
        public ActionResult Index()
        {
            return View(Db.BankAccounts.ToList().Where(x => x.ParentUserId == User.Identity.GetUserId()));
        }

        // GET: BankAccounts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BankAccount bankAccount = Db.BankAccounts.Find(id);

            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // GET: BankAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BankAccounts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ParentUserId,Iban,Currency,Amount")] BankAccount bankAccount)
        {
            if (!ModelState.IsValid) return View(bankAccount);

            Db.BankAccounts.Add(bankAccount);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: BankAccounts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var bankAccount = Db.BankAccounts.Find(id);

            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // POST: BankAccounts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ParentUserId,Iban,Currency,Amount")] BankAccount bankAccount)
        {
            if (!ModelState.IsValid) return View(bankAccount);

            Db.Entry(bankAccount).State = EntityState.Modified;
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: BankAccounts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var bankAccount = Db.BankAccounts.Find(id);

            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // POST: BankAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var bankAccount = Db.BankAccounts.Find(id);

            Db.BankAccounts.Remove(bankAccount);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
