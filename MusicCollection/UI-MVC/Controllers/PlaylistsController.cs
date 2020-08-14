using System.Web.Mvc;
using Shared;

namespace UI_MVC.Controllers
{
    public class PlaylistsController : Controller
    {
        private const string PATH = "playlists";
        //private IEnumerable<PlaylistDto> _playlists = ApiConsumer<PlaylistDto>.GetApi(PATH);

        // GET: Playlists
        public ActionResult Index()
        {
            return View();
        }

        // GET: Playlists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Playlists/Create
        [HttpPost]
        public ActionResult Create(PlaylistDto playlistDto)
        {
            ApiConsumer<PlaylistDto>.CreateObject(PATH, playlistDto);
            return RedirectToAction("Index");

            //try
            //{
            //    ApiConsumer<PlaylistDto>.CreateObject(PATH, playlistDto);
            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}