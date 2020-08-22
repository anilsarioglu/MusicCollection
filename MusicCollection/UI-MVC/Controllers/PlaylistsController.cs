using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using Shared;
using UI_MVC.Validators;

namespace UI_MVC.Controllers
{
    public class PlaylistsController : Controller
    {
        private const string PATH = "playlists";
        private readonly IEnumerable<PlaylistDto> _playlists = ApiConsumer<PlaylistDto>.GetApi(PATH);

        // GET: Playlists
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (_playlists == null)
            {
                return View();
            }

            var playlists = _playlists;

            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSortParm = string.IsNullOrEmpty(sortOrder) ? "Title_desc" : "";

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
                playlists = playlists.Where(
                    a => a.Title.ToLower().Contains(searchString) || a.Title.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Title_desc":
                    playlists = playlists.OrderByDescending(a => a.Title);
                    break;
                default:
                    playlists = playlists.OrderBy(a => a.Title);
                    break;
            }

            var pageNumber = page ?? 1;
            const int pageSize = 5;

            return View(playlists.ToPagedList(pageNumber, pageSize));
        }

        // GET: Playlists/New
        public ActionResult New()
        {
            ViewBag.NewOrEdit = "New";
            return View("PlaylistForm");
        }

        // POST: Playlists/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PlaylistDto playlistDto)
        {
            try
            {
                var playlistValidator = new PlaylistValidator();
                var result = playlistValidator.Validate(playlistDto);

                if (!result.IsValid)
                {
                    foreach (var failure in result.Errors)
                    {
                        ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                    }
                    return View("PlaylistForm", playlistDto);
                }

                if (playlistDto.Id == 0)
                {
                    ApiConsumer<PlaylistDto>.CreateObject(PATH, playlistDto);
                }
                else
                {
                    ApiConsumer<PlaylistDto>.UpdateObject(PATH, playlistDto);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View("PlaylistForm");
            }
        }

        // GET: Playlists/Edit/5
        public ActionResult Edit(int id)
        {
            var playlist = ApiConsumer<PlaylistDto>.GetObject(PATH, id);

            if (playlist == null)
            {
                return HttpNotFound();
            }

            ViewBag.NewOrEdit = "Edit";
            return View("PlaylistForm", playlist);
        }

        // GET: Playlists/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ApiConsumer<PlaylistDto>.GetObject(PATH, id));
        }

        // DELETE: Playlists/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PlaylistDto playlistDto)
        {
            try
            {
                ApiConsumer<ArtistDto>.DeleteObject(PATH, playlistDto.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}