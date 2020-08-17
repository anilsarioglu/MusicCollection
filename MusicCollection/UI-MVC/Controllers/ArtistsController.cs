using System.Collections.Generic;
using System.Web.Mvc;
using Shared;

namespace UI_MVC.Controllers
{
    public class ArtistsController : Controller
    {
        private const string PATH = "artists";
        private readonly IEnumerable<ArtistDto> _artists = ApiConsumer<ArtistDto>.GetApi(PATH);

        // GET: Artists
        public ActionResult Index()
        {
            return View(_artists);
        }

        // GET: Artists/Save
        public ActionResult New()
        {
            return View("ArtistForm");
        }

        // POST: Artists/Save
        [HttpPost]
        public ActionResult Save(ArtistDto artistDto)
        {
            try
            {
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