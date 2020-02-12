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
    public class InvoiceDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InvoiceDetails
        public ActionResult Index()
        {
            var invoiceDetails = db.InvoiceDetails.Include(i => i.InvoiceHeader).Include(i => i.StockMaster);
            return View(invoiceDetails.ToList());
        }

        // GET: InvoiceDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDetails invoiceDetails = db.InvoiceDetails.Find(id);
            if (invoiceDetails == null)
            {
                return HttpNotFound();
            }
            return View(invoiceDetails);
        }

        // GET: InvoiceDetails/Create
        public ActionResult Create()
        {
            ViewBag.ItemNo = new SelectList(db.InvoiceHeaders, "InvoiceNo", "InvoiceNo");
            ViewBag.StockCode = new SelectList(db.StockMasters, "StockId", "StockDescription");
            return View();
        }

        // POST: InvoiceDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceDetailsID,ItemNo,InvoiceNo,StockCode,QtySold,UnitCost,UnitSell,Disc,Total")] InvoiceDetails invoiceDetails)
        {
            if (ModelState.IsValid)
            {
                db.InvoiceDetails.Add(invoiceDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemNo = new SelectList(db.InvoiceHeaders, "InvoiceNo", "InvoiceNo", invoiceDetails.ItemNo);
            ViewBag.StockCode = new SelectList(db.StockMasters, "StockId", "StockDescription", invoiceDetails.StockCode);
            return View(invoiceDetails);
        }

        // GET: InvoiceDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDetails invoiceDetails = db.InvoiceDetails.Find(id);
            if (invoiceDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemNo = new SelectList(db.InvoiceHeaders, "InvoiceNo", "InvoiceNo", invoiceDetails.ItemNo);
            ViewBag.StockCode = new SelectList(db.StockMasters, "StockId", "StockDescription", invoiceDetails.StockCode);
            return View(invoiceDetails);
        }

        // POST: InvoiceDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceDetailsID,ItemNo,InvoiceNo,StockCode,QtySold,UnitCost,UnitSell,Disc,Total")] InvoiceDetails invoiceDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoiceDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemNo = new SelectList(db.InvoiceHeaders, "InvoiceNo", "InvoiceNo", invoiceDetails.ItemNo);
            ViewBag.StockCode = new SelectList(db.StockMasters, "StockId", "StockDescription", invoiceDetails.StockCode);
            return View(invoiceDetails);
        }

        // GET: InvoiceDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDetails invoiceDetails = db.InvoiceDetails.Find(id);
            if (invoiceDetails == null)
            {
                return HttpNotFound();
            }
            return View(invoiceDetails);
        }

        // POST: InvoiceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvoiceDetails invoiceDetails = db.InvoiceDetails.Find(id);
            db.InvoiceDetails.Remove(invoiceDetails);
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
