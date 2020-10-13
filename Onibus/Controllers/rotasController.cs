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
    public class rotasController : Controller
    {
        private contexto db = new contexto();

        // GET: rotas
        public ActionResult Index()
        {
            return View(db.rotas.ToList());
        }

        // GET: rotas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rota rota = db.rotas.Find(id);
            if (rota == null)
            {
                return HttpNotFound();
            }
            return View(rota);
        }

        // GET: rotas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: rotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RotasId,NomeRota")] rota rota)
        {
            if (ModelState.IsValid)
            {
                db.rotas.Add(rota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rota);
        }

        // GET: rotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rota rota = db.rotas.Find(id);
            if (rota == null)
            {
                return HttpNotFound();
            }
            return View(rota);
        }

        // POST: rotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RotasId,Rota")] rota rota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rota);
        }

        // GET: rotas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rota rota = db.rotas.Find(id);
            if (rota == null)
            {
                return HttpNotFound();
            }
            return View(rota);
        }

        // POST: rotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rota rota = db.rotas.Find(id);
            db.rotas.Remove(rota);
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
