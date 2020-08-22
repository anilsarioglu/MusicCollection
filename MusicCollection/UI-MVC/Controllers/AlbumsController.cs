﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using Shared;
using UI_MVC.Models;
using UI_MVC.Validators;
using UI_MVC.ViewModels;

namespace UI_MVC.Controllers
{
    public class AlbumsController : Controller
    {
        private const string PATH = "albums";
        private readonly IEnumerable<AlbumDto> _albums = ApiConsumer<AlbumDto>.GetApi(PATH);
        private readonly IEnumerable<ArtistDto> _artists = ApiConsumer<ArtistDto>.GetApi("artists");

        // GET: Albums
        public ActionResult Index(string searchString, string currentFilter, int? page, int? artistId)
        {
            var albums = _albums;

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
                albums = albums.Where(
                    a => a.Name.ToLower().Contains(searchString) || a.Name.Contains(searchString)
                                                                 || a.ReleaseDate.ToString(CultureInfo.InvariantCulture).Contains(searchString));
            }

            var pageNumber = page ?? 1;
            const int pageSize = 6;

            if (artistId.HasValue)
            {
                albums = albums.Where(album => album.ArtistId == artistId).ToList();

                var artistName = ApiConsumer<ArtistDto>.GetObject("artists", (int)artistId).Name;
                ViewBag.ArtistName = "of " + artistName;

                if (!User.IsInRole(RoleName.CanManageEverything))
                {
                    return View("ReadOnlyIndex", albums.ToPagedList(pageNumber, pageSize));
                }

                return View(albums.ToPagedList(pageNumber, pageSize));
            }

            if (!User.IsInRole(RoleName.CanManageEverything))
            {
                return View("ReadOnlyIndex", albums.ToPagedList(pageNumber, pageSize));
            }

            return View(albums.ToPagedList(pageNumber, pageSize));
        }



        // GET: Albums/New
        [Authorize(Roles = RoleName.CanManageEverything)]
        public ActionResult New()
        {
            var viewModel = new AlbumArtistViewModel()
            {
                Album = new AlbumDto(),
                Artists = _artists
            };

            ViewBag.NewOrEdit = "New";
            return View("AlbumForm", viewModel);
        }

        // POST: Albums/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageEverything)]
        public ActionResult Save(AlbumArtistViewModel albumArtistViewModel)
        {
            try
            {
                var albumArtistViewModelValidator = new AlbumArtistViewModelValidator();
                var result = albumArtistViewModelValidator.Validate(albumArtistViewModel);


                if (!result.IsValid)
                {
                    foreach (var failure in result.Errors)
                    {
                        ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                    }

                    albumArtistViewModel.Artists = _artists;

                    return View("AlbumForm", albumArtistViewModel);
                }

                if (albumArtistViewModel.Album.Id == 0)
                {
                    ApiConsumer<AlbumDto>.CreateObject(PATH, albumArtistViewModel.Album);
                }
                else
                {
                    ApiConsumer<AlbumDto>.UpdateObject(PATH, albumArtistViewModel.Album);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View("AlbumForm");
            }
        }

        // GET: Albums/Edit/5
        [Authorize(Roles = RoleName.CanManageEverything)]
        public ActionResult Edit(int id)
        {
            var album = ApiConsumer<AlbumDto>.GetObject(PATH, id);

            if (album == null)
            {
                return HttpNotFound();
            }

            var viewModel = new AlbumArtistViewModel()
            {
                Album = album,
                Artists = _artists
            };

            ViewBag.NewOrEdit = "Edit";
            return View("AlbumForm", viewModel);
        }

        // GET: Albums/Delete/5
        [Authorize(Roles = RoleName.CanManageEverything)]
        public ActionResult Delete(int id)
        {
            return View(ApiConsumer<AlbumDto>.GetObject(PATH, id));
        }

        // DELETE: Albums/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageEverything)]
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