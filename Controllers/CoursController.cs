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
    public class CoursController : Controller
    {
        private GovEgyDB2 db = new GovEgyDB2();

        // GET: Cours
        public ActionResult Index(string department)
        {
            var courses = db.Courses.Include(c => c.Department);
            if (!String.IsNullOrEmpty(department))
            {
                courses = courses.Where(p => p.Department.D_Name == department);
            }
            return View(courses.ToList());
        }




        // GET: Cours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = db.Courses.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

        // GET: Cours/Create
        public ActionResult Create()
        {
            ViewBag.D_Id = new SelectList(db.Departments, "D_Id", "D_Name");
            return View();
        }

        // POST: Cours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,C_Name,Price,Discount,C_Number,C_Mode,Discription,C_Image,C_File,D_Id")] Cours cours,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                //..\\Images\\
                if (file!=null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Content/Image/For_Reser/") + file.FileName);
                    cours.C_Image = file.FileName;
                }




                db.Courses.Add(cours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.D_Id = new SelectList(db.Departments, "D_Id", "D_Name", cours.D_Id);
            return View(cours);
        }

        // GET: Cours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = db.Courses.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            ViewBag.D_Id = new SelectList(db.Departments, "D_Id", "D_Name", cours.D_Id);
            return View(cours);
        }

        // POST: Cours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,C_Name,Price,Discount,C_Number,C_Mode,Discription,C_Image,C_File,D_Id")] Cours cours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.D_Id = new SelectList(db.Departments, "D_Id", "D_Name", cours.D_Id);
            return View(cours);
        }

        // GET: Cours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = db.Courses.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

        // POST: Cours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cours cours = db.Courses.Find(id);
            db.Courses.Remove(cours);
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
