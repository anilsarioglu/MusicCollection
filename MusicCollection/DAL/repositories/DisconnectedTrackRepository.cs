using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.repositories.interfaces;
using Domain;

namespace DAL.repositories
{
    public class DisconnectedTrackRepository : IDisconnectedRepository<Track>
    {
        public Track Create(Track track)
        {
            using (var context = new DatabaseContext())
            {
                var newTrack = context.Tracks.Add(track);
                context.SaveChanges();
                return newTrack;
            }
        }

        public IEnumerable<Track> ReadAll()
        {
            using (var context = new DatabaseContext())
            {
                return context.Tracks.ToList();
            }
        }

        //public IEnumerable<Genre> ReadAllTrackGenres()
        //{
        //    using (var context = new DatabaseContext())
        //    {
        //        var genres = context.Genres.SqlQuery("SELECT g.Name " +
        //                                             "FROM MusicCollection.Genre g " +
        //                                             "INNER JOIN MusicCollection.TrackGenres tg ON g.Id = tg.GenreId " +
        //                                             "INNER JOIN MusicCollection.Track t ON tg.TrackId = t.Id").ToList();
        //        return genres;
        //    }
        //}

        public Track ReadById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Tracks.Find(id);
            }
        }

        public Track Update(Track track)
        {
            using (var context = new DatabaseContext())
            {
                context.Entry(track).State = EntityState.Modified;
                context.SaveChanges();
                return track;
            }
        }

        public void DeleteById(int trackId)
        {
            using (var context = new DatabaseContext())
            {
                var track = context.Tracks.Find(trackId);
                context.Entry(track).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
