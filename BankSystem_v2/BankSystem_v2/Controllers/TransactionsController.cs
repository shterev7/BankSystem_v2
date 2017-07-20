namespace BankSystem_v2.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using DataAccess.Entity;

    public class TransactionsController : BaseController
    {
        // GET: Transactions
        public ActionResult Index()
        {
            return View(Db.Transactions.ToList());
        }

        // GET: Transactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var transaction = Db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transactions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ParentUserId,Type,Date,Iban,Currency,Amount")] Transaction transaction)
        {
            if (!ModelState.IsValid) return View(transaction);

            Db.Transactions.Add(transaction);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var transaction = Db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ParentUserId,Type,Date,Iban,Currency,Amount")] Transaction transaction)
        {
            if (!ModelState.IsValid) return View(transaction);

            Db.Entry(transaction).State = EntityState.Modified;
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var transaction = Db.Transactions.Find(id);

            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var transaction = Db.Transactions.Find(id);

            Db.Transactions.Remove(transaction);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
