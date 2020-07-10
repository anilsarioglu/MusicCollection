using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.entities;
using DAL.repositories.interfaces;

namespace DAL.repositories
{
    public class GenreRepository : IRepository<Genre>
    {
        private DatabaseContext _databaseContext;
        public GenreRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Genre Create(Genre genre)
        {
            try
            {
                _databaseContext.Genres.Add(genre);
                return genre;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Genre> ReadAll()
        {
            try
            {
                return _databaseContext.Genres.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public Genre ReadById(int id)
        {
            try
            {
                return _databaseContext.Genres.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Genre Update(Genre genre)
        {
            try
            {
                _databaseContext.Genres.AddOrUpdate(genre);
                return genre;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Remove(Genre genre)
        {
            try
            {
                var existingGenre = ReadById(genre.Id);
                _databaseContext.Genres.Remove(existingGenre);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
