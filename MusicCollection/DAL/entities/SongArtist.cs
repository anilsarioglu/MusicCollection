namespace DAL.entities
{
    public class SongArtist
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public int ArtistId { get; set; }
        public Song Song { get; set; }
        public Artist Artist { get; set; }

        public SongArtist()
        {
            
        }

        public SongArtist(int songId, int artistId)
        {
            SongId = songId;
            ArtistId = artistId;
        }
    }
}
