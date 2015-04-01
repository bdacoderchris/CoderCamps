using ComicBookApp.Data.Model;
using ComicBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicBookApp.Adapters.Mock
{
    public class MockComicAdapter : IComicAdapter
    {
        public IndexViewModel GetAllComics()
        {
            IndexViewModel vm = new IndexViewModel();
            vm.PageName = "Your Comic Book Collection!";
            vm.Comics = new List<Comic>();

            return vm;
        }
        public void CreateComic(CreateViewModel model)
        {

        }
        public UpdateViewModel ShowComic(int Id)
        {
            return new UpdateViewModel();
        }
        public void UpdateComic(UpdateViewModel model)
        {

        }
        public void DeleteComic(int Id)
        {

        }

    }
}