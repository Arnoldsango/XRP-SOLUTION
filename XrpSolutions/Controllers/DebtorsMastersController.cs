using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XrpSolutions.Models;

namespace XrpSolutions.Controllers
{
    public class DebtorsMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DebtorsMasters
        public ActionResult Index(string searchName)
        {
            return View(db.DebtorsMasters.Where(x=>x.Address1.Contains(searchName)|| searchName==null).ToList());
        }

        // GET: DebtorsMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebtorsMaster debtorsMaster = db.DebtorsMasters.Find(id);
            if (debtorsMaster == null)
            {
                return HttpNotFound();
            }
            return View(debtorsMaster);
        }
       //This is where we specify the highest and lowest functionality
        public ActionResult HigestDebtor()
        {
            var high = db.DebtorsMasters.OrderByDescending(x => x.Balance).Take(1);
            return View(high);
        }

        public ActionResult LowestDebtor()
        {
            var low = db.DebtorsMasters.OrderBy(x => x.Balance).Take(1);
            return View(low);
        }
        // GET: DebtorsMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DebtorsMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DebtorId,AccountCode,Address1,Address2,Address3,CostYearToDate,salesYearToDate,Balance")] DebtorsMaster debtorsMaster)
        {
            if (ModelState.IsValid)
            {

                debtorsMaster.Balance = debtorsMaster.CalcBalance();
                db.DebtorsMasters.Add(debtorsMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(debtorsMaster);
        }

        // GET: DebtorsMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebtorsMaster debtorsMaster = db.DebtorsMasters.Find(id);
            if (debtorsMaster == null)
            {
                return HttpNotFound();
            }
            return View(debtorsMaster);
        }

        // POST: DebtorsMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DebtorId,AccountCode,Address1,Address2,Address3,CostYearToDate,salesYearToDate,Balance")] DebtorsMaster debtorsMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(debtorsMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(debtorsMaster);
        }

        // GET: DebtorsMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebtorsMaster debtorsMaster = db.DebtorsMasters.Find(id);
            if (debtorsMaster == null)
            {
                return HttpNotFound();
            }
            return View(debtorsMaster);
        }

        // POST: DebtorsMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DebtorsMaster debtorsMaster = db.DebtorsMasters.Find(id);
            db.DebtorsMasters.Remove(debtorsMaster);
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
