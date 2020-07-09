namespace DAL.entities
{
    public class SongPlaylist
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public int PlaylistId { get; set; }
        public int OrderNo { get; set; }
        public Song Song { get; set; }
        public Playlist Playlist { get; set; }

        public SongPlaylist()
        {
            
        }

        public SongPlaylist(int songId, int playlistId, int orderNo)
        {
            SongId = songId;
            PlaylistId = playlistId;
            OrderNo = orderNo;
        }
    }
}
