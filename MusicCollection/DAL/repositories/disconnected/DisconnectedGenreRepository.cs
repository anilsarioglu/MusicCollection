using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.entities;
using DAL.repositories.interfaces;

namespace DAL.repositories.disconnected
{
    public class DisconnectedGenreRepository : IDisconnectedRepository<Genre>
    {
        public Genre Create(Genre genre)
        {
            using (var context = new DatabaseContext())
            {
                var newGenre = context.Genres.Add(genre);
                context.SaveChanges();
                return newGenre;
            }
        }

        public IEnumerable<Genre> ReadAll()
        {
            using (var context = new DatabaseContext())
            {
                return context.Genres.ToList();
            }
        }

        public Genre ReadById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Genres.Find(id);
            }
        }

        public Genre Update(Genre genre)
        {
            using (var context = new DatabaseContext())
            {
                context.Entry(genre).State = EntityState.Modified;
                context.SaveChanges();
                return genre;
            }
        }

        public void DeleteById(int genreId)
        {
            using (var context = new DatabaseContext())
            {
                var genre = context.Genres.Find(genreId);
                context.Entry(genre).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
