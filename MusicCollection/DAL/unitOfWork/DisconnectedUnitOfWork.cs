using DAL.repositories;

namespace DAL.unitOfWork
{
    public class DisconnectedUnitOfWork
    {
        private DisconnectedAlbumRepository _albumRepository;
        private DisconnectedArtistRepository _artistRepository;
        private DisconnectedGenreRepository _genreRepository;
        private DisconnectedPlaylistRepository _playlistRepository;
        private DisconnectedTrackRepository _trackRepository;

        public DisconnectedAlbumRepository AlbumRepository
        {
            get
            {

                if (this._albumRepository == null)
                {
                    this._albumRepository = new DisconnectedAlbumRepository();
                }
                return _albumRepository;
            }
        }

        public DisconnectedArtistRepository ArtistRepository
        {
            get
            {

                if (this._artistRepository == null)
                {
                    this._artistRepository = new DisconnectedArtistRepository();
                }
                return _artistRepository;
            }
        }

        public DisconnectedGenreRepository GenreRepository
        {
            get
            {

                if (this._genreRepository == null)
                {
                    this._genreRepository = new DisconnectedGenreRepository();
                }
                return _genreRepository;
            }
        }

        public DisconnectedPlaylistRepository PlaylistRepository
        {
            get
            {

                if (this._playlistRepository == null)
                {
                    this._playlistRepository = new DisconnectedPlaylistRepository();
                }
                return _playlistRepository;
            }
        }

        public DisconnectedTrackRepository TrackRepository
        {
            get
            {

                if (this._trackRepository == null)
                {
                    this._trackRepository = new DisconnectedTrackRepository();
                }
                return _trackRepository;
            }
        }
    }
}
