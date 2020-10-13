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
    public class viagensController : Controller
    {
        private contexto db = new contexto();

        // GET: viagens
        public ActionResult Index(string Pesquisa = "")
        {
            var q = db.Viagens.AsQueryable();
            if (!string.IsNullOrEmpty(Pesquisa))
                q = q.Where(c => c.DataViagem.Contains(Pesquisa));
            q = q.OrderBy(c => c.DataViagem);

            return View(q.ToList());
        }

        // GET: viagens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            viagem viagem = db.Viagens.Find(id);
            if (viagem == null)
            {
                return HttpNotFound();
            }
            return View(viagem);
        }

        // GET: viagens/Create
        public ActionResult Create()
        {
            // Session["Funcionarios"] = new SelectList(db.Motoristas, "FuncionarioId", "Nome");
            ViewBag.Rotas = new SelectList(db.rotas, "RotasId", "NomeRota");
            ViewBag.Trabalhadores = new SelectList(db.trabalhadors, "TrabalhadorId", "Nome");
            ViewBag.Veiculos = new SelectList(db.Motoristas, "VeiculoID", "Modelo");
            return View();
        }

        // POST: viagens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,VeiculoId,TrabalhadorId,RotasId,HorarioViagem,Custo,PosicaoVeiculo,DataViagem")] viagem viagem)
        {
            if (ModelState.IsValid)
            {

                //subtopico.TopicoId = Convert.ToInt32(Request.Params["Topico"]);
                db.Viagens.Add(viagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viagem);
        }

        // GET: viagens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            viagem viagem = db.Viagens.Find(id);
            if (viagem == null)
            {
                return HttpNotFound();
            }
            return View(viagem);
        }

        // POST: viagens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,VeiculoDd,TrabalhdorId,RotasId,HorarioViagem,Custo,PosicaoVeiculo,DataViagem")] viagem viagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viagem);
        }

        // GET: viagens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            viagem viagem = db.Viagens.Find(id);
            if (viagem == null)
            {
                return HttpNotFound();
            }
            return View(viagem);
        }

        // POST: viagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            viagem viagem = db.Viagens.Find(id);
            db.Viagens.Remove(viagem);
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
