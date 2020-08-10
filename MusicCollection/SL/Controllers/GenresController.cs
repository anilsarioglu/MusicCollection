using System;
using System.Linq;
using System.Web.Http;
using BLL.managers;
using BLL.managers.interfaces;
using Shared;

namespace SL.Controllers
{
    public class GenresController : ApiController
    {
        private IManager<GenreDto> _genreManager;

        //public GenresController(GenreManager genreManager)
        //{
        //    _genreManager = genreManager;
        //}

        public GenresController()
        {
            _genreManager = new GenreManager();
        }

        // GET: api/Genres
        public IHttpActionResult GetGenres()
        {
            return Ok(_genreManager.ReadAll().AsEnumerable());
        }

        // GET: api/Genres/5
        public IHttpActionResult GetGenre(int id)
        {
            var genre = _genreManager.ReadById(id);

            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }

        // POST: api/Genres
        [HttpPost]
        public IHttpActionResult PostGenre(GenreDto genreDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _genreManager.Create(genreDto);
            return Created(new Uri(Request.RequestUri + "/" + genreDto.Id), genreDto);
        }

        // PUT: api/Genres/5
        [HttpPut]
        public IHttpActionResult PutGenre(GenreDto genreDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var genreInDb = _genreManager.ReadById(genreDto.Id);

            if (genreInDb == null)
            {
                return NotFound();
            }

            return Ok(_genreManager.Update(genreDto));
        }

        // DELETE: api/Genres/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var genreInDb = _genreManager.ReadById(id);

            if (genreInDb == null)
            {
                return NotFound();
            }

            _genreManager.Delete(genreInDb.Id);
            return Ok();
        }
    }
}
