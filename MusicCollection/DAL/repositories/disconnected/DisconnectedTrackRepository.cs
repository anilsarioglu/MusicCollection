﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.entities;
using DAL.repositories.interfaces;

namespace DAL.repositories.disconnected
{
    public class DisconnectedTrackRepository : IDisconnectedRepository<Track>
    {
        public Track Create(Track track)
        {
            using (var context = new DatabaseContext())
            {
                var newTrack = context.Tracks.Add(track);
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
