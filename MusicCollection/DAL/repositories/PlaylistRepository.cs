using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.entities;
using DAL.repositories.interfaces;

namespace DAL.repositories
{
    public class PlaylistRepository : IRepository<Playlist>
    {
        private DatabaseContext _databaseContext;
        public PlaylistRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Playlist Create(Playlist playlist)
        {
            try
            {
                _databaseContext.Playlists.Add(playlist);
                return playlist;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Playlist> ReadAll()
        {
            try
            {
                return _databaseContext.Playlists.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public Playlist ReadById(int id)
        {
            try
            {
                return _databaseContext.Playlists.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Playlist Update(Playlist playlist)
        {
            try
            {
                _databaseContext.Playlists.AddOrUpdate(playlist);
                return playlist;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(Playlist playlist)
        {
            try
            {
                var existingPlaylist = ReadById(playlist.Id);
                _databaseContext.Playlists.Remove(existingPlaylist);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
