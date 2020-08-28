using System;
using System.Linq;
using System.Web.Http;
using BLL.Managers;
using BLL.managers.interfaces;
using Shared;

namespace SL.Controllers
{
    public class TrackGenresController : ApiController
    {
        private IManager<TrackGenreDto> _trackGenreManager;

        //public TrackGenresController(TrackGenreManager trackGenreManager)
        //{
        //    _trackGenreManager = trackGenreManager;
        //}

        public TrackGenresController()
        {
            _trackGenreManager = new TrackGenreManager();
        }

        // GET: api/TrackGenres
        public IHttpActionResult GetTrackGenres()
        {
            return Ok(_trackGenreManager.ReadAll().AsEnumerable());
        }

        // GET: api/TrackGenres/5
        public IHttpActionResult GetTrackGenre(int id)
        {
            var trackGenre = _trackGenreManager.ReadById(id);

            if (trackGenre == null)
            {
                return NotFound();
            }

            return Ok(trackGenre);
        }

        // POST: api/TrackGenres
        [HttpPost]
        public IHttpActionResult PostTrackGenre(TrackGenreDto trackGenreDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _trackGenreManager.Create(trackGenreDto);
            return Created(new Uri(Request.RequestUri + "/" + trackGenreDto.Id), trackGenreDto);
        }

        // PUT: api/TrackGenres/5
        [HttpPut]
        public IHttpActionResult PutTrackGenre(TrackGenreDto trackGenreDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var trackGenreInDb = _trackGenreManager.ReadById(trackGenreDto.Id);

            if (trackGenreInDb == null)
            {
                return NotFound();
            }

            return Ok(_trackGenreManager.Update(trackGenreDto));
        }

        // DELETE: api/TrackGenres/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var trackGenreInDb = _trackGenreManager.ReadById(id);

            if (trackGenreInDb == null)
            {
                return NotFound();
            }

            _trackGenreManager.Delete(trackGenreInDb.Id);
            return Ok();
        }
    }
}
