using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.repositories.interfaces;
using Domain;

namespace DAL.Repositories
{
    public class DisconnectedTrackGenreRepository : IDisconnectedRepository<TrackGenre>
    {
        public TrackGenre Create(TrackGenre trackGenre)
        {
            using (var context = new DatabaseContext())
            {
                var newTrackGenre = context.TrackGenres.Add(trackGenre);
                context.SaveChanges();
                return newTrackGenre;
            }
        }

        public IEnumerable<TrackGenre> ReadAll()
        {
            using (var context = new DatabaseContext())
            {
                return context.TrackGenres.ToList();
            }
        }

        public TrackGenre ReadById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.TrackGenres.Find(id);
            }
        }

        public TrackGenre Update(TrackGenre trackGenre)
        {
            using (var context = new DatabaseContext())
            {
                context.Entry(trackGenre).State = EntityState.Modified;
                context.SaveChanges();
                return trackGenre;
            }
        }

        public void DeleteById(int trackGenreId)
        {
            using (var context = new DatabaseContext())
            {
                var trackGenre = context.TrackGenres.Find(trackGenreId);
                context.Entry(trackGenre).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
