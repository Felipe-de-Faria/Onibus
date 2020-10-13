using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Onibus.Models;

namespace Onibus.Controllers
{
    public class trabalhadoresController : Controller
    {
        private contexto db = new contexto();

        // GET: trabalhadores
        public ActionResult Index()
        {
            return View(db.trabalhadors.ToList());
        }

        // GET: trabalhadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trabalhador trabalhador = db.trabalhadors.Find(id);
            if (trabalhador == null)
            {
                return HttpNotFound();
            }
            return View(trabalhador);
        }

        // GET: trabalhadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: trabalhadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrabalhadorId,Nome")] trabalhador trabalhador)
        {
            if (ModelState.IsValid)
            {
                db.trabalhadors.Add(trabalhador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trabalhador);
        }

        // GET: trabalhadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trabalhador trabalhador = db.trabalhadors.Find(id);
            if (trabalhador == null)
            {
                return HttpNotFound();
            }
            return View(trabalhador);
        }

        // POST: trabalhadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrabalhadorId,Nome")] trabalhador trabalhador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabalhador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trabalhador);
        }

        // GET: trabalhadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trabalhador trabalhador = db.trabalhadors.Find(id);
            if (trabalhador == null)
            {
                return HttpNotFound();
            }
            return View(trabalhador);
        }

        // POST: trabalhadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trabalhador trabalhador = db.trabalhadors.Find(id);
            db.trabalhadors.Remove(trabalhador);
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
