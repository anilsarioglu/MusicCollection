using System.Web.Mvc;
using Shared;

namespace UI_MVC.Controllers
{
    public class TracksController : Controller
    {
        private const string PATH = "tracks";
        //private IEnumerable<TrackDto> _tracks = ApiConsumer<TrackDto>.GetApi(PATH);

        // GET: Tracks
        public ActionResult Index()
        {
            return View();
        }

        // GET: Tracks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tracks/Create
        [HttpPost]
        public ActionResult Create(TrackDto trackDto)
        {
            ApiConsumer<TrackDto>.CreateObject(PATH, trackDto);
            return RedirectToAction("Index");

            //try
            //{
            //    ApiConsumer<TrackDto>.CreateObject(PATH, trackDto);
            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}