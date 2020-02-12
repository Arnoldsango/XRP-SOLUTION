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
    public class StockTransactionFilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StockTransactionFiles
        public ActionResult Index()
        {
            var stockTransactionFiles = db.StockTransactionFiles.Include(s => s.Stock);
            return View(stockTransactionFiles.ToList());
        }

        // GET: StockTransactionFiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTransactionFile stockTransactionFile = db.StockTransactionFiles.Find(id);
            if (stockTransactionFile == null)
            {
                return HttpNotFound();
            }
            return View(stockTransactionFile);
        }

        // GET: StockTransactionFiles/Create
        public ActionResult Create()
        {
            ViewBag.StockCode = new SelectList(db.StockMasters, "StockId", "StockDescription");
            return View();
        }

        // POST: StockTransactionFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StockTransactionId,DocumentNo,StockCode,Date,TransactionType,Qty,UnitCost,UnitSell")] StockTransactionFile stockTransactionFile)
        {
            if (ModelState.IsValid)
            {
                db.StockTransactionFiles.Add(stockTransactionFile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StockCode = new SelectList(db.StockMasters, "StockId", "StockDescription", stockTransactionFile.StockCode);
            return View(stockTransactionFile);
        }

        // GET: StockTransactionFiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTransactionFile stockTransactionFile = db.StockTransactionFiles.Find(id);
            if (stockTransactionFile == null)
            {
                return HttpNotFound();
            }
            ViewBag.StockCode = new SelectList(db.StockMasters, "StockId", "StockDescription", stockTransactionFile.StockCode);
            return View(stockTransactionFile);
        }

        // POST: StockTransactionFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StockTransactionId,DocumentNo,StockCode,Date,TransactionType,Qty,UnitCost,UnitSell")] StockTransactionFile stockTransactionFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockTransactionFile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StockCode = new SelectList(db.StockMasters, "StockId", "StockDescription", stockTransactionFile.StockCode);
            return View(stockTransactionFile);
        }

        // GET: StockTransactionFiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTransactionFile stockTransactionFile = db.StockTransactionFiles.Find(id);
            if (stockTransactionFile == null)
            {
                return HttpNotFound();
            }
            return View(stockTransactionFile);
        }

        // POST: StockTransactionFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockTransactionFile stockTransactionFile = db.StockTransactionFiles.Find(id);
            db.StockTransactionFiles.Remove(stockTransactionFile);
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
