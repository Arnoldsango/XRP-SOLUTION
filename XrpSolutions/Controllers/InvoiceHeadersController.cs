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
    public class InvoiceHeadersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InvoiceHeaders
        public ActionResult Index()
        {
            return View(db.InvoiceHeaders.ToList());
        }

        // GET: InvoiceHeaders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceHeader invoiceHeader = db.InvoiceHeaders.Find(id);
            if (invoiceHeader == null)
            {
                return HttpNotFound();
            }
            return View(invoiceHeader);
        }

        // GET: InvoiceHeaders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceHeaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceNo,AccountCode,Date,Vat,TotalSellexclVat,TotalCost")] InvoiceHeader invoiceHeader)
        {
            if (ModelState.IsValid)
            {
                db.InvoiceHeaders.Add(invoiceHeader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(invoiceHeader);
        }

        // GET: InvoiceHeaders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceHeader invoiceHeader = db.InvoiceHeaders.Find(id);
            if (invoiceHeader == null)
            {
                return HttpNotFound();
            }
            return View(invoiceHeader);
        }

        // POST: InvoiceHeaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceNo,AccountCode,Date,Vat,TotalSellexclVat,TotalCost")] InvoiceHeader invoiceHeader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoiceHeader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invoiceHeader);
        }

        // GET: InvoiceHeaders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceHeader invoiceHeader = db.InvoiceHeaders.Find(id);
            if (invoiceHeader == null)
            {
                return HttpNotFound();
            }
            return View(invoiceHeader);
        }

        // POST: InvoiceHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvoiceHeader invoiceHeader = db.InvoiceHeaders.Find(id);
            db.InvoiceHeaders.Remove(invoiceHeader);
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
