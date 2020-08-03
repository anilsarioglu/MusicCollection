using System;
using System.Linq;
using System.Web.Http;
using BLL.managers;
using BLL.managers.interfaces;
using Shared;

namespace SL.Controllers
{
    public class AlbumsController : ApiController
    {
        private IManager<AlbumDto> _albumManager;

        public AlbumsController(AlbumManager albumManager)
        {
            _albumManager = albumManager;
        }

        // GET: api/Albums
        public IHttpActionResult GetAlbums()
        {
            return Ok(_albumManager.ReadAll().AsEnumerable());
        }

        // GET: api/Albums/5
        public IHttpActionResult GetAlbum(int id)
        {
            var album = _albumManager.ReadById(id);

            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }

        // POST: api/Albums
        [HttpPost]
        public IHttpActionResult PostAlbum(AlbumDto albumDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _albumManager.Create(albumDto);
            return Created(new Uri(Request.RequestUri + "/" + albumDto.Id), albumDto);
        }

        // PUT: api/Albums/5
        [HttpPut]
        public IHttpActionResult PutAlbum(AlbumDto albumDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var albumInDb = _albumManager.ReadById(albumDto.Id);

            if (albumInDb == null)
            {
                return NotFound();
            }

            return Ok(_albumManager.Update(albumDto));
        }

        // DELETE: api/Albums/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var albumInDb = _albumManager.ReadById(id);

            if (albumInDb == null)
            {
                return NotFound();
            }

            _albumManager.Delete(albumInDb.Id);
            return Ok();
        }
    }
}
