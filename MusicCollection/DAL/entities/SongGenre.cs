namespace DAL.entities
{
    public class SongGenre
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public int GenreId { get; set; }
        public Song Song { get; set; }
        public Genre Genre { get; set; }

        public SongGenre()
        {
            
        }

        public SongGenre(int songId, int genreId)
        {
            SongId = songId;
            GenreId = genreId;
        }
    }
}
