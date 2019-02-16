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
    public class BaseballCardsController : Controller
    {
        private CollectContext db = new CollectContext();

        // GET: BaseballCards
        [Route("Cards/Baseball/All")]
        public ActionResult Index()
        {
            //archive
            // var baseballCards = db.BaseballCards.Include(b => b.ManufacturerInfo).Include(b => b.Player);
            // return View(baseballCards.ToList());


            //gets the model
            var BaseballCards = db.BaseballCard.ToList();
            //combines the model with view and return
            return View(BaseballCards);
        }


        // GET: BaseballCards/Details/5
        [Route("Cards/Baseball/{id:int}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseballCard baseballCard = db.BaseballCard.Find(id);
            if (baseballCard == null)
            {
                return HttpNotFound();
            }
            return View(baseballCard);
        }
        [Authorize(Roles = "Administrator")]
        // GET: BaseballCards/Create
        public ActionResult Create()
        {
            ViewBag.ManufacturerID = new SelectList(db.ManufacturerInfo, "ManufacturerID", "ManufacturerName");
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName");
            ViewBag.CoachID = new SelectList(db.Coach, "CoachID", "CoachName");
            ViewBag.TeamID = new SelectList(db.Team, "TeamID", "TeamName");
            ViewBag.PositionID = new SelectList(db.Position, "PositionID", "PositionName");
            return View();
        }

        // POST: BaseballCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BaseballCardID,CardNumber,TeamID,PlayerID,CoachID,PlayerNumber,PositionID,ManufacturerID,CardYear")] BaseballCard baseballCard)
        {
            if (ModelState.IsValid)
            {
                db.BaseballCard.Add(baseballCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManufacturerID = new SelectList(db.ManufacturerInfo, "ManufacturerID", "ManufacturerName", baseballCard.ManufacturerID);
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", baseballCard.PlayerID);
            ViewBag.CoachID = new SelectList(db.Coach, "CoachID", "CoachName", baseballCard.CoachID);
            ViewBag.TeamID = new SelectList(db.Team, "TeamID", "TeamName", baseballCard.TeamID);
            ViewBag.PositionID = new SelectList(db.Position, "PositionID", "PositionName", baseballCard.PositionID);
            return View(baseballCard);
        }

        // GET: BaseballCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseballCard baseballCard = db.BaseballCard.Find(id);
            if (baseballCard == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManufacturerID = new SelectList(db.ManufacturerInfo, "ManufacturerID", "ManufacturerName", baseballCard.ManufacturerID);
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", baseballCard.PlayerID);
            ViewBag.CoachID = new SelectList(db.Coach, "CoachID", "CoachName", baseballCard.CoachID);
            ViewBag.TeamID = new SelectList(db.Team, "TeamID", "TeamName", baseballCard.TeamID);
            ViewBag.PositionID = new SelectList(db.Position, "PositionID", "PositionName", baseballCard.PositionID);
            return View(baseballCard);
        }

        // POST: BaseballCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BaseballCardID,CardNumber,TeamID,PlayerID,CoachID,PlayerNumber,PositionID,ManufacturerID,CardYear")] BaseballCard baseballCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baseballCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManufacturerID = new SelectList(db.ManufacturerInfo, "ManufacturerID", "ManufacturerName", baseballCard.ManufacturerID);
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", baseballCard.PlayerID);
            ViewBag.CoachID = new SelectList(db.Coach, "CoachID", "CoachName", baseballCard.CoachID);
            ViewBag.TeamID = new SelectList(db.Team, "TeamID", "TeamName", baseballCard.TeamID);
            ViewBag.PositionID = new SelectList(db.Position, "PositionID", "PositionName", baseballCard.PositionID);
            return View(baseballCard);
        }

        // GET: BaseballCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseballCard baseballCard = db.BaseballCard.Find(id);
            if (baseballCard == null)
            {
                return HttpNotFound();
            }
            return View(baseballCard);
        }

        // POST: BaseballCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaseballCard baseballCard = db.BaseballCard.Find(id);
            db.BaseballCard.Remove(baseballCard);
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


        // ADD: BaseballCards/AddToCollection/5
        [Route("Cards/Baseball/Add/{id:int}")]
        public ActionResult Add(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseballCard baseballCard = db.BaseballCard.Find(id);
            if (baseballCard == null)
            {
                return HttpNotFound();
            }
            return View(baseballCard);
        }


    }
}
