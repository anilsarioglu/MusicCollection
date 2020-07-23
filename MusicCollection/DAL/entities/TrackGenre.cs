namespace DAL.entities
{
    public class TrackGenre
    {
        public int Id { get; set; }
        public int TrackId { get; set; }
        public int GenreId { get; set; }
        public Track Track { get; set; }
        public Genre Genre { get; set; }

        public TrackGenre()
        {
            
        }

        public TrackGenre(int trackId, int genreId)
        {
            TrackId = trackId;
            GenreId = genreId;
        }
    }
}
