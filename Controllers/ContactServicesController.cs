using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GovEgy_2.Models;

namespace GovEgy_2.Controllers
{
    public class ContactServicesController : Controller
    {
        private GovEgyDB2 db = new GovEgyDB2();

        // GET: ContactServices
        public ActionResult Index()
        {
            var contactServices = db.ContactServices.Include(c => c.ServiceType_2);
            return View(contactServices.ToList());
        }

        // GET: ContactServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactService contactService = db.ContactServices.Find(id);
            if (contactService == null)
            {
                return HttpNotFound();
            }
            return View(contactService);
        }

        // GET: ContactServices/Create
        public ActionResult Create()
        {
            ViewBag.S_id = new SelectList(db.ServiceType_2, "S_id", "ServiceType");
            return View();
        }

        // POST: ContactServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Phone,Email,Service_Type,Details,S_id")] ContactService contactService)
        {
            if (ModelState.IsValid)
            {
                db.ContactServices.Add(contactService);
                db.SaveChanges();
                return RedirectToAction("Message");
            }

            ViewBag.S_id = new SelectList(db.ServiceType_2, "S_id", "ServiceType", contactService.S_id);
            return View(contactService);
        }

        // GET: ContactServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactService contactService = db.ContactServices.Find(id);
            if (contactService == null)
            {
                return HttpNotFound();
            }
            ViewBag.S_id = new SelectList(db.ServiceType_2, "S_id", "ServiceType", contactService.S_id);
            return View(contactService);
        }

        // POST: ContactServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Phone,Email,Service_Type,Details,S_id")] ContactService contactService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.S_id = new SelectList(db.ServiceType_2, "S_id", "ServiceType", contactService.S_id);
            return View(contactService);
        }

        // GET: ContactServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactService contactService = db.ContactServices.Find(id);
            if (contactService == null)
            {
                return HttpNotFound();
            }
            return View(contactService);
        }

        // POST: ContactServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactService contactService = db.ContactServices.Find(id);
            db.ContactServices.Remove(contactService);
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


        public ActionResult Message()
        {
            return View();
        }
    }
}
