using System;
using System.Linq;
using System.Web.Http;
using BLL.managers;
using BLL.managers.interfaces;
using Shared;

namespace SL.Controllers
{
    public class TracksController : ApiController
    {
        private IManager<TrackDto> _trackManager;

        public TracksController(TrackManager trackManager)
        {
            _trackManager = trackManager;
        }

        // GET: api/Tracks
        public IHttpActionResult GetTracks()
        {
            return Ok(_trackManager.ReadAll().AsEnumerable());
        }

        // GET: api/Tracks/5
        public IHttpActionResult GetTrack(int id)
        {
            var track = _trackManager.ReadById(id);

            if (track == null)
            {
                return NotFound();
            }

            return Ok(track);
        }

        // POST: api/Tracks
        [HttpPost]
        public IHttpActionResult PostTrack(TrackDto trackDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _trackManager.Create(trackDto);
            return Created(new Uri(Request.RequestUri + "/" + trackDto.Id), trackDto);
        }

        // PUT: api/Tracks/5
        [HttpPut]
        public IHttpActionResult PutTrack(TrackDto trackDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var trackInDb = _trackManager.ReadById(trackDto.Id);

            if (trackInDb == null)
            {
                return NotFound();
            }

            return Ok(_trackManager.Update(trackDto));
        }

        // DELETE: api/Tracks/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var trackInDb = _trackManager.ReadById(id);

            if (trackInDb == null)
            {
                return NotFound();
            }

            _trackManager.Delete(trackInDb.Id);
            return Ok();
        }
    }
}
