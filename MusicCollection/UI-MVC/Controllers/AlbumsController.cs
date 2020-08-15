using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Shared;

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
                return View(_albums);
            }

            var albumArtists = _albums.Where(album => album.ArtistId == id).ToList();

            return View(albumArtists);
        }

        // GET: Albums/Save
        public ActionResult Save()
        {
            return View();
        }

        // POST: Albums/Save
        [HttpPost]
        public ActionResult Save(AlbumDto albumDto)
        {
            try
            {
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
                return View();
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

            return View("Save", album);
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