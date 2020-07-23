namespace DAL.entities
{
    public class PlaylistTrack
    {
        public int Id { get; set; }
        public int TrackId { get; set; }
        public int PlaylistId { get; set; }
        public int OrderNo { get; set; }
        public Track Track { get; set; }
        public Playlist Playlist { get; set; }

        public PlaylistTrack()
        {
            
        }

        public PlaylistTrack(int trackId, int playlistId, int orderNo)
        {
            TrackId = trackId;
            PlaylistId = playlistId;
            OrderNo = orderNo;
        }
    }
}
