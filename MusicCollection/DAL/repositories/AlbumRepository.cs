using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.entities;
using DAL.repositories.interfaces;

namespace DAL.repositories
{
    public class AlbumRepository : IRepository<Album>
    {
        private DatabaseContext _databaseContext;
        public AlbumRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Album Create(Album album)
        {
            try
            {
                _databaseContext.Albums.Add(album);
                return album;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Album> ReadAll()
        {
            try
            {
                return _databaseContext.Albums.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public Album ReadById(int id)
        {
            try
            {
                return _databaseContext.Albums.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Album Update(Album album)
        {
            try
            {
                _databaseContext.Albums.AddOrUpdate(album);
                return album;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Remove(Album album)
        {
            try
            {
                var existingAlbum = ReadById(album.Id);
                _databaseContext.Albums.Remove(existingAlbum);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
