using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using Shared;
using UI_MVC.Validators;

namespace UI_MVC.Controllers
{
    public class GenresController : Controller
    {
        private const string PATH = "genres";
        private readonly IEnumerable<GenreDto> _genres = ApiConsumer<GenreDto>.GetApi(PATH);

        // GET: Genres
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var genres = _genres;

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                genres = genres.Where(
                    g => g.Name.ToLower().Contains(searchString) || g.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Name_desc":
                    genres = genres.OrderByDescending(g => g.Name);
                    break;
                default:
                    genres = genres.OrderBy(g => g.Name);
                    break;
            }

            var pageNumber = page ?? 1;
            const int pageSize = 5;

            return View(genres.ToPagedList(pageNumber, pageSize));
        }

        // GET: Genres/New
        public ActionResult New()
        {
            ViewBag.NewOrEdit = "New";
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

            ViewBag.NewOrEdit = "Edit";
            return View("GenreForm", genre);
        }

        // GET: Genres/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ApiConsumer<GenreDto>.GetObject(PATH, id));
        }

        // DELETE: Genres/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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