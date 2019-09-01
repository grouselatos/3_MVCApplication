using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _3_MVCApplication.Managers;
using _3_MVCApplication.Models;

namespace _3_MVCApplication.Controllers
{
    public class ActorsController : Controller
    {
        private DbManager db = new DbManager();
        // GET: Actors
        public ActionResult Index()
        {
            var actors = db.GetActors(); // o typos ths metavlhths einai Icollection alla vazoume var gia eukolia
            ViewData["message"] = "We are on index page!"; // idia leitourgia me to viewbag alla pio palia edkoxh!
            return View(actors); // mporei na ginei kai View(db.GetActors) apeutheias
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Message = "We are on create page!"; // to viewbag xrhsimeuei na pernaw mnm apo enan controller mesa se ena view
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            db.AddActor(actor); // edw h forma tou xrhsth epikoinwnei me to backend kai th database
            TempData["notification-message"] = "Actor inserted successfully!"; // metaferei message apo action se action, kai pws auto tha ginei render sto view
            TempData["notification-color"] = "success";
            //to session xrhsimopoieitai gia kalathi proiontwn, login logout ktl ktl
            Session["Actions"] = (int)Session["Actions"] + 1; //metrhths meta apo kathe action, me casting se int. xwris to int tha eprepe na arxikopoiithei to session apo prin
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Actor actor = db.GetActor(id);
            if (actor==null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            db.UpdateActor(actor);
            TempData["notification-message"] = "Actor edited successfully!"; // metaferei message apo action se action, kai pws auto tha ginei render sto view
            Session["Actions"] = (int)Session["Actions"] + 1; //metrhths meta apo kathe action, me casting se int. xwris to int tha eprepe na arxikopoiithei to session apo prin
            TempData["notification-color"] = "warning";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Actor actor = db.GetActor(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        [HttpPost]
        [ActionName("Delete")] // ftiaxnei thn idia URL kai gia to post
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            db.DeleteActor(id);
            TempData["notification-message"] = "Actor deleted successfully!"; // metaferei message apo action se action, kai pws auto tha ginei render sto view
            Session["Actions"] = (int)Session["Actions"] + 1; //metrhths meta apo kathe action, me casting se int. xwris to int tha eprepe na arxikopoiithei to session apo prin
            TempData["notification-color"] = "danger";
            return RedirectToAction("Index");
        }
    }
}