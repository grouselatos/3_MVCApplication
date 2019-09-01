using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _3_MVCApplication.Managers;
using _3_MVCApplication.Models;

namespace _3_MVCApplication.Controllers
{
    public class CategoriesController : Controller
    {
        private DbManager db = new DbManager();
        // GET: Categories
        public ActionResult Index()
        {
            var categories = db.GetCategories();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            db.AddCategory(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            Category category = db.GetCategory(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            db.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }

}