﻿using System.Collections.Generic;
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

        // GET: Artists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        [HttpPost]
        public ActionResult Create(ArtistDto artistDto)
        {
            try
            {
                ApiConsumer<ArtistDto>.CreateObject(PATH, artistDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}