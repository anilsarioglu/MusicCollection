using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Shared;
using UI_MVC.Validators;

namespace UI_MVC.Controllers
{
    public class AlbumsController : Controller
    {
        private const string PATH = "albums";
        private readonly IEnumerable<AlbumDto> _albums = ApiConsumer<AlbumDto>.GetApi(PATH);

        // GET: Albums
        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.ArtistName = "";
                return View(_albums);
            }

            var albumArtists = _albums.Where(album => album.ArtistId == id).ToList();

            var artistName = ApiConsumer<ArtistDto>.GetObject("artists", (int)id).Name;
            ViewBag.ArtistName = "of " + artistName;

            return View(albumArtists);
        }

        // GET: Albums/New
        public ActionResult New()
        {
            ViewBag.NewOrEdit = "New";
            return View("AlbumForm");
        }

        // POST: Albums/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(AlbumDto albumDto)
        {
            try
            {
                var albumValidator = new AlbumValidator();
                var result = albumValidator.Validate(albumDto);

                if (!result.IsValid)
                {
                    foreach (var failure in result.Errors)
                    {
                        ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                    }
                    return View("AlbumForm", albumDto);
                }

                if (albumDto.Id == 0)
                {
                    ApiConsumer<AlbumDto>.CreateObject(PATH, albumDto);
                }
                else
                {
                    ApiConsumer<AlbumDto>.UpdateObject(PATH, albumDto);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View("AlbumForm");
            }
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int id)
        {
            var album = ApiConsumer<AlbumDto>.GetObject(PATH, id);

            if (album == null)
            {
                return HttpNotFound();
            }

            ViewBag.NewOrEdit = "Edit";
            return View("AlbumForm", album);
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ApiConsumer<AlbumDto>.GetObject(PATH, id));
        }

        // DELETE: Albums/Delete/5
        [HttpPost]
        public ActionResult Delete(AlbumDto albumDto)
        {
            try
            {
                ApiConsumer<AlbumDto>.DeleteObject(PATH, albumDto.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}