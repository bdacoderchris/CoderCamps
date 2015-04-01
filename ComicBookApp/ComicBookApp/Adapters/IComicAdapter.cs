using ComicBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookApp.Adapters
{
    public interface IComicAdapter
    {
        IndexViewModel GetAllComics();

        void CreateComic(CreateViewModel model);

        UpdateViewModel ShowComic(int Id);

        void UpdateComic(UpdateViewModel model);

        void DeleteComic(int Id);
    }
}
