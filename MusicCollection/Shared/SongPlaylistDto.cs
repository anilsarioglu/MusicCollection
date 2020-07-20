namespace Shared
{
    public class SongPlaylistDto
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public int PlaylistId { get; set; }
        public int OrderNo { get; set; }
        public SongDto Song { get; set; }
        public PlaylistDto Playlist { get; set; }
    }
}
