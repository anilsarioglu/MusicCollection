using System.Collections.Generic;
using System.Web.Mvc;
using Shared;

namespace UI_MVC.Controllers
{
    public class ArtistsController : Controller
    {
        private const string PATH = "artist";
        private IEnumerable<ArtistDto> _artists = ApiConsumer<ArtistDto>.GetApi(PATH);

        // GET: Artists
        public ActionResult Index()
        {
            return View();
        }

        // GET: Invoice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invoice/Create
        [HttpPost]
        public ActionResult Create(ArtistDto artistDto)
        {
            try
            {
                ApiConsumer<ArtistDto>.AddObject(PATH, artistDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}