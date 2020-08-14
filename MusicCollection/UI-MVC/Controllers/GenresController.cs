using System.Web.Mvc;
using Shared;

namespace UI_MVC.Controllers
{
    public class GenresController : Controller
    {
        private const string PATH = "genres";
        //private IEnumerable<GenreDto> _genres = ApiConsumer<GenreDto>.GetApi(PATH);

        // GET: Genres
        public ActionResult Index()
        {
            return View();
        }

        // GET: Genres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        [HttpPost]
        public ActionResult Create(GenreDto genreDto)
        {
            ApiConsumer<GenreDto>.CreateObject(PATH, genreDto);
            return RedirectToAction("Index");

            //try
            //{
            //    ApiConsumer<GenreDto>.CreateObject(PATH, genreDto);
            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}