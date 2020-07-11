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
                return context.Genres.Add(genre);
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
                return genre;
            }
        }

        public void DeleteById(int genreId)
        {
            using (var context = new DatabaseContext())
            {
                var genre = context.Genres.Find(genreId);
                context.Entry(genre).State = EntityState.Deleted;
            }
        }
    }
}
