using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _3_MVCApplication.Managers;
using _3_MVCApplication.Models;

namespace _3_MVCApplication.Controllers
{
    public class DirectorsController : Controller
    {
        // GET: Directors
        private DbManager db = new DbManager();
        public ActionResult Index()
        {
            var directors = db.GetDirectors(); // o typos ths metavlhths einai Icollection alla vazoume var gia eukolia
            return View(directors); // mporei na ginei kai View(db.GetActors) apeutheias
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Director director)
        {
            if (!ModelState.IsValid)
            {
                return View(director);
            }

            db.AddDirector(director); // edw h forma tou xrhsth epikoinwnei me to backend kai th database
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Director director = db.GetDirector(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Director director)
        {
            if (!ModelState.IsValid)
            {
                return View(director);
            }

            db.UpdateDirector(director);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Director director = db.GetDirector(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        [HttpPost]
        [ActionName("Delete")] // ftiaxnei thn idia URL kai gia to post
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            db.DeleteDirector(id);
            return RedirectToAction("Index");
        }
    }
}