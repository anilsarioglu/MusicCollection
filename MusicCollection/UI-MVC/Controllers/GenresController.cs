using System.Collections.Generic;
using System.Web.Mvc;
using Shared;
using UI_MVC.Validators;

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

        // GET: Genres/New
        public ActionResult New()
        {
            return View("GenreForm");
        }

        // POST: Genres/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(GenreDto genreDto)
        {
            try
            {
                var genreValidator = new GenreValidator();
                var result = genreValidator.Validate(genreDto);

                if (!result.IsValid)
                {
                    foreach (var failure in result.Errors)
                    {
                        ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                    }
                    return View("GenreForm", genreDto);
                }

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
                return View("GenreForm");
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

            return View("GenreForm", genre);
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