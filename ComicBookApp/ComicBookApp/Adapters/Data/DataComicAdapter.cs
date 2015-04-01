using ComicBookApp.Data;
using ComicBookApp.Data.Model;
using ComicBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicBookApp.Adapters.Data
{
    public class DataComicAdapter : IComicAdapter
    {
        public IndexViewModel GetAllComics()
        {
            IndexViewModel vvm = new IndexViewModel();
            vvm.PageName = "Comic Book Collection";
            vvm.Comics = new List<Comic>();
            using (ComicDbContext db = new ComicDbContext())
            {
                vvm.Comics = db.Comics.ToList();
            }
            return vvm;
        }
        public void CreateComic(CreateViewModel model)
        {
            CreateViewModel vm = new CreateViewModel();
            
            Comic TempComic = new Comic();
            TempComic.Title = model.Title;
            TempComic.Author = model.Author;
            TempComic.Cover = model.Cover;
            //TempComic.Studio = model.Studio;
            TempComic.StudioId = 1;
            using (ComicDbContext db = new ComicDbContext())
            {
                db.Comics.Add(TempComic);
                db.SaveChanges();
            }
        }
        public UpdateViewModel ShowComic(int Id)
        {
            UpdateViewModel vm = new UpdateViewModel();
            using (ComicDbContext db = new ComicDbContext())
            {
                vm.Comic = db.Comics.Find(Id);
            }
            return vm;
        }
        public void UpdateComic(UpdateViewModel model)
        {
            using (ComicDbContext db = new ComicDbContext())
            {
                Comic tc = new Comic();
                tc = db.Comics.Find(model.Comic.ComicId);
                tc.Title = model.Comic.Title;
                tc.Author = model.Comic.Author;
                tc.Cover = model.Comic.Cover;
                tc.Studio = model.Comic.Studio;
                db.SaveChanges();
            }
        }
        public void DeleteComic(int Id)
        {
            using (ComicDbContext db = new ComicDbContext())
            {
                Comic tc = new Comic();
                tc = db.Comics.Find(Id);
                db.Comics.Remove(tc);
                db.SaveChanges();
            }
        }
    }
}