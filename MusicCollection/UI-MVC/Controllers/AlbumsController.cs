using System.Collections.Generic;
using System.Web.Mvc;
using Shared;

namespace UI_MVC.Controllers
{
    public class AlbumsController : Controller
    {
        private const string PATH = "albums";
        private readonly IEnumerable<AlbumDto> _albums = ApiConsumer<AlbumDto>.GetApi(PATH);

        // GET: Albums
        public ActionResult Index()
        {
            return View(_albums);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        [HttpPost]
        public ActionResult Create(AlbumDto albumDto)
        {
            try
            {
                ApiConsumer<AlbumDto>.CreateObject(PATH, albumDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}