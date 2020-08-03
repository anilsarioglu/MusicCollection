using System;
using System.Linq;
using System.Web.Http;
using BLL.managers;
using BLL.managers.interfaces;
using Shared;

namespace SL.Controllers
{
    public class PlaylistsController : ApiController
    {
        private IManager<PlaylistDto> _playlistManager;

        public PlaylistsController(PlaylistManager playlistManager)
        {
            _playlistManager = playlistManager;
        }

        // GET: api/Playlists
        public IHttpActionResult GetPlaylists()
        {
            return Ok(_playlistManager.ReadAll().AsEnumerable());
        }

        // GET: api/Playlists/5
        public IHttpActionResult GetPlaylist(int id)
        {
            var playlist = _playlistManager.ReadById(id);

            if (playlist == null)
            {
                return NotFound();
            }

            return Ok(playlist);
        }

        // POST: api/Playlists
        [HttpPost]
        public IHttpActionResult PostPlaylist(PlaylistDto playlistDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _playlistManager.Create(playlistDto);
            return Created(new Uri(Request.RequestUri + "/" + playlistDto.Id), playlistDto);
        }

        // PUT: api/Playlists/5
        [HttpPut]
        public IHttpActionResult PutPlaylist(PlaylistDto playlistDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var playlistInDb = _playlistManager.ReadById(playlistDto.Id);

            if (playlistInDb == null)
            {
                return NotFound();
            }

            return Ok(_playlistManager.Update(playlistDto));
        }

        // DELETE: api/Playlists/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var playlistInDb = _playlistManager.ReadById(id);

            if (playlistInDb == null)
            {
                return NotFound();
            }

            _playlistManager.Delete(playlistInDb.Id);
            return Ok();
        }
    }
}
