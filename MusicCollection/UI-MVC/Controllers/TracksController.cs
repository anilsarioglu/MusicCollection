using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using Shared;
using UI_MVC.Validators;
using UI_MVC.ViewModels;

namespace UI_MVC.Controllers
{
    public class TracksController : Controller
    {
        private const string PATH = "tracks";
        private readonly IEnumerable<TrackDto> _tracks = ApiConsumer<TrackDto>.GetApi(PATH);
        private readonly IEnumerable<GenreDto> _genres = ApiConsumer<GenreDto>.GetApi("genres");

        // GET: Tracks
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (_tracks == null)
            {
                return View();
            }

            var tracks = _tracks;

            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSortParm = string.IsNullOrEmpty(sortOrder) ? "Title_desc" : "";
            ViewBag.DurationSortParm = sortOrder == "Duration" ? "Duration_desc" : "Duration";
            ViewBag.LabelSortParm = sortOrder == "Label" ? "Label_desc" : "Label";

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
                tracks = tracks.Where(
                    a => a.Title.ToLower().Contains(searchString) || a.Title.Contains(searchString) 
                                                                  || a.Duration.ToString().Contains(searchString)
                                                                  || a.Label.ToLower().Contains(searchString)
                                                                  || a.Label.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Title_desc":
                    tracks = tracks.OrderByDescending(a => a.Title);
                    break;
                case "Duration":
                    tracks = tracks.OrderBy(a => a.Duration);
                    break;
                case "Duration_desc":
                    tracks = tracks.OrderByDescending(a => a.Duration);
                    break;
                case "Label":
                    tracks = tracks.OrderBy(a => a.Label);
                    break;
                case "Label_desc":
                    tracks = tracks.OrderByDescending(a => a.Label);
                    break;
                default:
                    tracks = tracks.OrderBy(a => a.Title);
                    break;
            }

            var pageNumber = page ?? 1;
            const int pageSize = 5;

            return View(tracks.ToPagedList(pageNumber, pageSize));
        }

        // GET: Tracks/New
        public ActionResult New()
        {
            var viewModel = new TrackGenreViewModel
            {
                Track = new TrackDto(),
                Genres = _genres,
                TrackGenre = new TrackGenreDto()
            };

            ViewBag.NewOrEdit = "New";
            return View("TrackForm", viewModel);
        }

        // POST: Tracks/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(TrackGenreViewModel trackGenreViewModel)
        {
            try
            {
                var trackGenreViewValidator = new TrackGenreViewModelValidator();
                var result = trackGenreViewValidator.Validate(trackGenreViewModel);

                if (!result.IsValid)
                {
                    foreach (var failure in result.Errors)
                    {
                        ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                    }

                    trackGenreViewModel.Genres = _genres;

                    return View("TrackForm", trackGenreViewModel);
                }

                if (trackGenreViewModel.Track.Id == 0)
                {
                    ApiConsumer<TrackDto>.CreateObject(PATH, trackGenreViewModel.Track);
                }
                else
                {
                    ApiConsumer<TrackDto>.UpdateObject(PATH, trackGenreViewModel.Track);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View("TrackForm");
            }
        }

        // GET: Tracks/Edit/5
        public ActionResult Edit(int id)
        {
            var track = ApiConsumer<TrackDto>.GetObject(PATH, id);

            if (track == null)
            {
                return HttpNotFound();
            }

            var viewModel = new TrackGenreViewModel()
            {
                Genres = _genres,
                Track = track,
                TrackGenre = new TrackGenreDto()
            };

            ViewBag.NewOrEdit = "Edit";
            return View("TrackForm", viewModel);
        }

        // GET: Tracks/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ApiConsumer<TrackDto>.GetObject(PATH, id));
        }

        // DELETE: Tracks/Delete/5
        [HttpPost]
        public ActionResult Delete(TrackDto trackDto)
        {
            try
            {
                ApiConsumer<ArtistDto>.DeleteObject(PATH, trackDto.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}