using System.Collections.Generic;
using System.Web.Mvc;
using Shared;

namespace UI_MVC.Controllers
{
    public class GenresController : Controller
    {
        private const string PATH = "genres";
        private readonly IEnumerable<GenreDto> _genres = ApiConsumer<GenreDto>.GetApi(PATH);

        // GET: Genres
        public ActionResult Index()
        {
            return View(_genres);
        }

        // GET: Genres/Save
        public ActionResult Save()
        {
            return View();
        }

        // POST: Genres/Save
        [HttpPost]
        public ActionResult Save(GenreDto genreDto)
        {
            try
            {
                if (genreDto.Id == 0)
                {
                    ApiConsumer<GenreDto>.CreateObject(PATH, genreDto);
                }
                else
                {
                    ApiConsumer<GenreDto>.UpdateObject(PATH, genreDto);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Genres/Edit/5
        public ActionResult Edit(int id)
        {
            var genre = ApiConsumer<GenreDto>.GetObject(PATH, id);

            if (genre == null)
            {
                return HttpNotFound();
            }

            return View("Save", genre);
        }

        // GET: Genres/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ApiConsumer<GenreDto>.GetObject(PATH, id));
        }

        // DELETE: Genres/Delete/5
        [HttpPost]
        public ActionResult Delete(GenreDto genreDto)
        {
            try
            {
                ApiConsumer<GenreDto>.DeleteObject(PATH, genreDto.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}