using System.Collections.Generic;

namespace Shared
{
    public class PlaylistDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<SongPlaylistDto> SongPlaylistList { get; set; }
    }
}
