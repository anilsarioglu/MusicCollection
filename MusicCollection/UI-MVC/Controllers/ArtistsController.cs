using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using Shared;
using UI_MVC.Validators;

namespace UI_MVC.Controllers
{
    public class ArtistsController : Controller
    {
        private const string PATH = "artists";
        private readonly IEnumerable<ArtistDto> _artists = ApiConsumer<ArtistDto>.GetApi(PATH);

        // GET: Artists
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var artists = _artists;

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.BirthdateSortParm = sortOrder == "Birthdate" ? "Birthdate_desc" : "Birthdate";

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
                artists = artists.Where(
                    a => a.Name.ToLower().Contains(searchString) || a.Name.Contains(searchString)
                         || a.Birthdate.ToString(CultureInfo.InvariantCulture).Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Name_desc":
                    artists = artists.OrderByDescending(a => a.Name);
                    break;
                case "Birthdate":
                    artists = artists.OrderBy(a => a.Birthdate);
                    break;
                case "Birthdate_desc":
                    artists = artists.OrderByDescending(a => a.Birthdate);
                    break;
                default:
                    artists = artists.OrderBy(a => a.Name);
                    break;
            }

            var pageNumber = page ?? 1;
            const int pageSize = 5;

            return View(artists.ToPagedList(pageNumber, pageSize));
        }

        // GET: Artists/New
        public ActionResult New()
        {
            ViewBag.NewOrEdit = "New";
            return View("ArtistForm");
        }

        // POST: Artists/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ArtistDto artistDto)
        {
            try
            {
                var artistValidator = new ArtistValidator();
                var result = artistValidator.Validate(artistDto);

                if (!result.IsValid)
                {
                    foreach (var failure in result.Errors)
                    {
                        ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                    }
                    return View("ArtistForm", artistDto);
                }

                if (artistDto.Id == 0)
                {
                    ApiConsumer<ArtistDto>.CreateObject(PATH, artistDto);
                }
                else
                {
                    ApiConsumer<ArtistDto>.UpdateObject(PATH, artistDto);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View("ArtistForm");
            }
        }

        // GET: Artists/Edit/5
        public ActionResult Edit(int id)
        {
            var artist = ApiConsumer<ArtistDto>.GetObject(PATH, id);

            if (artist == null)
            {
                return HttpNotFound();
            }

            ViewBag.NewOrEdit = "Edit";
            return View("ArtistForm", artist);
        }

        // GET: Artists/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ApiConsumer<ArtistDto>.GetObject(PATH, id));
        }

        // DELETE: Artist/Delete/5
        [HttpPost]
        public ActionResult Delete(ArtistDto artistDto)
        {
            try
            {
                ApiConsumer<ArtistDto>.DeleteObject(PATH, artistDto.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}