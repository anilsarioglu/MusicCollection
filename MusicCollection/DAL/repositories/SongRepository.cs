using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.entities;
using DAL.repositories.interfaces;

namespace DAL.repositories
{
    public class SongRepository : IRepository<Song>
    {
        private DatabaseContext _databaseContext;
        public SongRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Song Create(Song song)
        {
            try
            {
                _databaseContext.Songs.Add(song);
                return song;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Song> ReadAll()
        {
            try
            {
                return _databaseContext.Songs.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }   

        public Song ReadById(int id)
        {
            try
            {
                return _databaseContext.Songs.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Song Update(Song song)
        {
            try
            {
                _databaseContext.Songs.AddOrUpdate(song);
                return song;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Remove(Song song)
        {
            try
            {
                var existingSong = ReadById(song.Id);
                _databaseContext.Songs.Remove(existingSong);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
