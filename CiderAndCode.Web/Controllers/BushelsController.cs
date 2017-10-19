using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CiderAndCode.Web.DataModels;

namespace CiderAndCode.Web.Controllers
{
    public class BushelsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Bushels
        public ActionResult Index()
        {
            return View(db.Bushels.ToList());
        }

        // GET: Bushels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bushel bushel = db.Bushels.Find(id);
            if (bushel == null)
            {
                return HttpNotFound();
            }
            return View(bushel);
        }

        // GET: Bushels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bushels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Quantity,Ripe,Pressed")] Bushel bushel)
        {
            if (ModelState.IsValid)
            {
                db.Bushels.Add(bushel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bushel);
        }

        // GET: Bushels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bushel bushel = db.Bushels.Find(id);
            if (bushel == null)
            {
                return HttpNotFound();
            }
            return View(bushel);
        }

        // POST: Bushels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,Quantity,Ripe,Pressed")] Bushel bushel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bushel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bushel);
        }

        // GET: Bushels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bushel bushel = db.Bushels.Find(id);
            if (bushel == null)
            {
                return HttpNotFound();
            }
            return View(bushel);
        }

        // POST: Bushels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bushel bushel = db.Bushels.Find(id);
            db.Bushels.Remove(bushel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
