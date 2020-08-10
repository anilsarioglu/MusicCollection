using System;
using System.Linq;
using System.Web.Http;
using BLL.managers;
using BLL.managers.interfaces;
using Shared;

namespace SL.Controllers
{
    public class ArtistsController : ApiController
    {
        private IManager<ArtistDto> _artistManager;

        //public ArtistsController(ArtistManager artistManager)
        //{
        //    _artistManager = artistManager;
        //}

        public ArtistsController()
        {
            _artistManager = new ArtistManager();
        }

        // GET: api/Artists
        public IHttpActionResult GetArtists()
        {
            return Ok(_artistManager.ReadAll().AsEnumerable());
        }

        // GET: api/Artists/5
        public IHttpActionResult GetArtist(int id)
        {
            var artist = _artistManager.ReadById(id);

            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        // POST: api/Artists
        [HttpPost]
        public IHttpActionResult PostArtist(ArtistDto artistDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _artistManager.Create(artistDto);
            return Created(new Uri(Request.RequestUri + "/" + artistDto.Id), artistDto);
        }

        // PUT: api/Artists/5
        [HttpPut]
        public IHttpActionResult PutArtist(ArtistDto artistDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var artistInDb = _artistManager.ReadById(artistDto.Id);

            if (artistInDb == null)
            {
                return NotFound();
            }

            return Ok(_artistManager.Update(artistDto));
        }

        // DELETE: api/Artists/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var artistInDb = _artistManager.ReadById(id);

            if (artistInDb == null)
            {
                return NotFound();
            }

            _artistManager.Delete(artistInDb.Id);
            return Ok();
        }
    }
}
