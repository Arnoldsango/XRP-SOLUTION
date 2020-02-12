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
    public class DebtorTransactionFilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DebtorTransactionFiles
        public ActionResult Index()
        {
            var debtorTransactionFiles = db.DebtorTransactionFiles.Include(d => d.DebtorsMaster);
            return View(debtorTransactionFiles.ToList());
        }

        // GET: DebtorTransactionFiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebtorTransactionFile debtorTransactionFile = db.DebtorTransactionFiles.Find(id);
            if (debtorTransactionFile == null)
            {
                return HttpNotFound();
            }
            return View(debtorTransactionFile);
        }

        // GET: DebtorTransactionFiles/Create
        public ActionResult Create()
        {
            ViewBag.AccountCode = new SelectList(db.DebtorsMasters, "DebtorId", "Address1");
            return View();
        }

        // POST: DebtorTransactionFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DbTransactionId,DocumentNo,AccountCode,Date,TransactionType,GrossTransactionValue,VatValue")] DebtorTransactionFile debtorTransactionFile)
        {
            if (ModelState.IsValid)
            {
                debtorTransactionFile.VatValue = debtorTransactionFile.VatValueCalc();
                db.DebtorTransactionFiles.Add(debtorTransactionFile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountCode = new SelectList(db.DebtorsMasters, "DebtorId", "Address1", debtorTransactionFile.AccountCode);
            return View(debtorTransactionFile);
        }

        // GET: DebtorTransactionFiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebtorTransactionFile debtorTransactionFile = db.DebtorTransactionFiles.Find(id);
            if (debtorTransactionFile == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountCode = new SelectList(db.DebtorsMasters, "DebtorId", "Address1", debtorTransactionFile.AccountCode);
            return View(debtorTransactionFile);
        }

        // POST: DebtorTransactionFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DbTransactionId,DocumentNo,AccountCode,Date,TransactionType,GrossTransactionValue,VatValue")] DebtorTransactionFile debtorTransactionFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(debtorTransactionFile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountCode = new SelectList(db.DebtorsMasters, "DebtorId", "Address1", debtorTransactionFile.AccountCode);
            return View(debtorTransactionFile);
        }

        // GET: DebtorTransactionFiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebtorTransactionFile debtorTransactionFile = db.DebtorTransactionFiles.Find(id);
            if (debtorTransactionFile == null)
            {
                return HttpNotFound();
            }
            return View(debtorTransactionFile);
        }

        // POST: DebtorTransactionFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DebtorTransactionFile debtorTransactionFile = db.DebtorTransactionFiles.Find(id);
            db.DebtorTransactionFiles.Remove(debtorTransactionFile);
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
