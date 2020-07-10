using System;
using DAL.repositories;

namespace DAL.unitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private DatabaseContext _databaseContext = new DatabaseContext();

        private AlbumRepository _albumRepository;
        private ArtistRepository _artistRepository;
        private GenreRepository _genreRepository;
        private PlaylistRepository _playlistRepository;
        private SongRepository _songRepository;

        public AlbumRepository AlbumRepository
        {
            get
            {

                if (this._albumRepository == null)
                {
                    this._albumRepository = new AlbumRepository(_databaseContext);
                }
                return _albumRepository;
            }
        }

        public ArtistRepository ArtistRepository
        {
            get
            {

                if (this._artistRepository == null)
                {
                    this._artistRepository = new ArtistRepository(_databaseContext);
                }
                return _artistRepository;
            }
        }

        public GenreRepository GenreRepository
        {
            get
            {

                if (this._genreRepository == null)
                {
                    this._genreRepository = new GenreRepository(_databaseContext);
                }
                return _genreRepository;
            }
        }

        public PlaylistRepository PlaylistRepository
        {
            get
            {

                if (this._playlistRepository == null)
                {
                    this._playlistRepository = new PlaylistRepository(_databaseContext);
                }
                return _playlistRepository;
            }
        }

        public SongRepository SongRepository
        {
            get
            {

                if (this._songRepository == null)
                {
                    this._songRepository = new SongRepository(_databaseContext);
                }
                return _songRepository;
            }
        }

        public void Save()
        {

            _databaseContext.SaveChanges();
        }


        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _databaseContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
