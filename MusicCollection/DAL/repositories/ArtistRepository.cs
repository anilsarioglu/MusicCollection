using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.entities;
using DAL.repositories.interfaces;

namespace DAL.repositories
{
    public class ArtistRepository : IRepository<Artist>
    {
        private DatabaseContext _databaseContext;
        public ArtistRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Artist Create(Artist artist)
        {
            try
            {
                _databaseContext.Artists.Add(artist);
                return artist;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Artist> ReadAll()
        {
            try
            {
                return _databaseContext.Artists.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }   

        public Artist ReadById(int id)
        {
            try
            {
                return _databaseContext.Artists.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Artist Update(Artist artist)
        {
            try
            {
                _databaseContext.Artists.AddOrUpdate(artist);
                return artist;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(Artist artist)
        {
            try
            {
                var existingArtist = ReadById(artist.Id);
                _databaseContext.Artists.Remove(existingArtist);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
