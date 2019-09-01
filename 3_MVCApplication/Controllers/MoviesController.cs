using _3_MVCApplication.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _3_MVCApplication.Models;
using _3_MVCApplication.ViewModels;

namespace _3_MVCApplication.Controllers
{
    public class MoviesController : Controller
    {
        private DbManager db = new DbManager();
        // GET: Movies
        public ActionResult Index()
        {
            var movies = db.GetMovies();
            return View(movies);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //Get categories and create Selectlist in the view
            ViewBag.DirectorId = new SelectList(db.GetDirectors(), "Id", "Name");
            var categories = db.GetCategories();
            ViewBag.Genre = new SelectList(categories, "Name", "Name"); // to db.GetCategories mporei na mpei kateutheian sto 1o parameter xwris metavlhth
            MovieViewModel vm = new MovieViewModel()
            {
                Movie = new Movie(),
                Actors = db.GetActors().Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
            };
            //papapanw tou les na ftiaksei ena movieviewmodel kai meta arxikopoieis to property twn actors mesa apo auto to movieviewmodel.
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.DirectorId = new SelectList(db.GetDirectors(), "Id", "Name", vm.Movie.DirectorId);
                var categories = db.GetCategories();
                ViewBag.Genre = new SelectList(categories, "Name", "Name", vm.Movie.Genre); // mporei na mpei kateutheian sto 1o parameter xwris metavlhth
                return View(vm);
            }
            db.AddMovie(vm.Movie, vm.SelectedActors);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Movie movie = db.GetMovie(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.DirectorId = new SelectList(db.GetDirectors(), "Id", "Name", movie.DirectorId);
            ViewBag.Genre = new SelectList(db.GetCategories(), "Name", "Name", movie.Genre);
            MovieViewModel vm = new MovieViewModel()
            {
                Movie = movie,
                Actors = db.GetActors().Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MovieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.DirectorId = new SelectList(db.GetDirectors(), "Id", "Name", vm.Movie.DirectorId);
                ViewBag.Genre = new SelectList(db.GetCategories(), "Name", "Name", vm.Movie.Genre);
                return View(vm);
            }
            db.UpdateMovie(vm.Movie, vm.SelectedActors);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Movie movie = db.GetMovieFull(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost]
        [ActionName("Delete")] // ftiaxnei thn idia URL kai gia to post epeidh allakse to onoma ths se sxesh me th get
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            db.DeleteMovie(id);
            return RedirectToAction("Index");
        }
    }
}