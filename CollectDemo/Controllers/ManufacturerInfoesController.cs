using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CollectDemo.Models;

namespace CollectDemo.Controllers
{
    [RoutePrefix("Manu/Baseball")]
    public class ManufacturerInfoesController : Controller
    {
        private CollectContext db = new CollectContext();

        // GET: ManufacturerInfoes
        [Route("All")]
        public ActionResult Index()
        {
            //archive
            // return View(db.ManufacturerInfoes.ToList());

            
            //gets the model
            var ManufacturerInfoes = db.ManufacturerInfo.ToList();
            //combine the model with the view and return
            return View(ManufacturerInfoes);
        }

        // GET: ManufacturerInfoes/Details/5
        [Route("Manu/Baseball/{id:int}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManufacturerInfo manufacturerInfo = db.ManufacturerInfo.Find(id);
            if (manufacturerInfo == null)
            {
                return HttpNotFound();
            }
            return View(manufacturerInfo);
        }

        // GET: ManufacturerInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManufacturerInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ManufacturerID,ManufacturerName")] ManufacturerInfo manufacturerInfo)
        {
            if (ModelState.IsValid)
            {
                db.ManufacturerInfo.Add(manufacturerInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manufacturerInfo);
        }

        // GET: ManufacturerInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManufacturerInfo manufacturerInfo = db.ManufacturerInfo.Find(id);
            if (manufacturerInfo == null)
            {
                return HttpNotFound();
            }
            return View(manufacturerInfo);
        }

        // POST: ManufacturerInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ManufacturerID,ManufacturerName")] ManufacturerInfo manufacturerInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manufacturerInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manufacturerInfo);
        }

        // GET: ManufacturerInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManufacturerInfo manufacturerInfo = db.ManufacturerInfo.Find(id);
            if (manufacturerInfo == null)
            {
                return HttpNotFound();
            }
            return View(manufacturerInfo);
        }

        // POST: ManufacturerInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManufacturerInfo manufacturerInfo = db.ManufacturerInfo.Find(id);
            db.ManufacturerInfo.Remove(manufacturerInfo);
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
