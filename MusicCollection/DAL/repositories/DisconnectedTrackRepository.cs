using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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
                var tracks = context.Tracks.SqlQuery("SELECT * " +
                                                     "FROM MusicCollection.Track ").ToList();
                return tracks;
            }
        }

        public Track ReadById(int id)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var paramId = new SqlParameter("@TrackId", id);
                    var track = context.Tracks.SqlQuery("GetTrackById @TrackId", paramId).First();
                    return track;
                }
            }
            catch (Exception)
            {
                return null;
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
