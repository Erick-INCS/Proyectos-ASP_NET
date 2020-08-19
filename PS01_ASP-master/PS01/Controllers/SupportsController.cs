﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PS01.Models;

namespace PS01.Controllers
{
    public class SupportsController : Controller
    {
        private NetSodtDbContext db = new NetSodtDbContext();

        // GET: Supports
        public ActionResult Index()
        {
            return View(db.Supports.ToList());
        }

        // GET: Supports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Support support = db.Supports.Find(id);
            if (support == null)
            {
                return HttpNotFound();
            }
            return View(support);
        }

        // GET: Supports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supports/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Support support)
        {
            if (ModelState.IsValid)
            {
                db.Supports.Add(support);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(support);
        }

        // GET: Supports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Support support = db.Supports.Find(id);
            if (support == null)
            {
                return HttpNotFound();
            }
            return View(support);
        }

        // POST: Supports/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,ProblemDescription,Solution")] Support support)
        {
            if (ModelState.IsValid)
            {
                db.Entry(support).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(support);
        }

        // GET: Supports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Support support = db.Supports.Find(id);
            if (support == null)
            {
                return HttpNotFound();
            }
            return View(support);
        }

        // POST: Supports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Support support = db.Supports.Find(id);
            db.Supports.Remove(support);
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
