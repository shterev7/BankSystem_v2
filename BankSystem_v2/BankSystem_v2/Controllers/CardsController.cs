namespace BankSystem_v2.Controllers
{
    using System.Net;
    using System.Linq;
    using System.Web.Mvc;
    using DataAccess.Entity;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity;

    public class CardsController : BaseController, IController
    {
        // GET: Cards
        public ActionResult Index()
        {
            return View(Db.Cards.ToList().Where(x => x.ParentUserId == User.Identity.GetUserId()));
        }

        // GET: Cards/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Card card = Db.Cards.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        // GET: Cards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cards/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ParentAccountId,CardNumber,CardType,Currency,Amount,ValidThru")] Card card)
        {
            if (!ModelState.IsValid) return View(card);

            Db.Cards.Add(card);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Cards/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Card card = Db.Cards.Find(id);

            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        // POST: Cards/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ParentAccountId,CardNumber,CardType,Currency,Amount,ValidThru")] Card card)
        {
            if (!ModelState.IsValid) return View(card);

            Db.Entry(card).State = EntityState.Modified;
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Cards/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Card card = Db.Cards.Find(id);

            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Card card = Db.Cards.Find(id);
            Db.Cards.Remove(card);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
