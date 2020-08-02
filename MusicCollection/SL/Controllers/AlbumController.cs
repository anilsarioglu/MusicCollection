using System.Linq;
using System.Web.Http;
using BLL.managers;
using BLL.managers.interfaces;
using Shared;

namespace SL.Controllers
{
    public class AlbumController : ApiController
    {
        private IManager<AlbumDto> _manager;

        public AlbumController(IManager<AlbumDto> manager)
        {
            _manager = manager;
        }

        // GET: api/Album
        public IHttpActionResult GetAlbums()
        {
            return Ok(_manager.ReadAll().AsEnumerable());
        }

        // GET: api/Album/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Album
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Album/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Album/5
        public void Delete(int id)
        {
        }
    }
}
