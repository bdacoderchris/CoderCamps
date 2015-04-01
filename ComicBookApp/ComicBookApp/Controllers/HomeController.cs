using ComicBookApp.Adapters;
using ComicBookApp.Adapters.Data;
using ComicBookApp.Data;
using ComicBookApp.Data.Model;
using ComicBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ComicBookApp.Controllers
{
    public class HomeController : Controller
    {
        IComicAdapter _comicAdapter;

        public HomeController()
        {
            _comicAdapter = new DataComicAdapter();
            //_comicAdapter = new MockDataAdapter();
        }
        public HomeController(IComicAdapter adapter)
        {
            _comicAdapter = adapter;
        }
        public ActionResult Index()
        {

            var vm = _comicAdapter.GetAllComics();
            /*
            IndexViewModel vm = new IndexViewModel();
            vm.PageName = "Comic Book Collection";
            vm.Comics = new List<Comic>();
            using (ComicDbContext db = new ComicDbContext())
            {
                vm.Comics = db.Comics.ToList();
            }
             */
            return View(vm);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateViewModel model)
        {
            _comicAdapter.CreateComic(model);
            return RedirectToAction("Index");
        }
        
        public ActionResult Update(int Id)
        {
            var vm = _comicAdapter.ShowComic(Id);
            return View(vm);
        }
        [HttpPost]
        public ActionResult Update(UpdateViewModel model)
        {
            _comicAdapter.UpdateComic(model);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            _comicAdapter.DeleteComic(Id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            ComicDbContext db = new ComicDbContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comic comic = db.Comics.Find(id);
            if (comic == null)
            {
                return HttpNotFound();
            }
            return View(comic);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}