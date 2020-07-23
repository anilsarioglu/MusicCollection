using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.entities;
using DAL.repositories.interfaces;

namespace DAL.repositories
{
    public class TrackRepository : IRepository<Track>
    {
        private DatabaseContext _databaseContext;
        public TrackRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Track Create(Track track)
        {
            try
            {
                _databaseContext.Tracks.Add(track);
                return track;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Track> ReadAll()
        {
            try
            {
                return _databaseContext.Tracks.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }   

        public Track ReadById(int id)
        {
            try
            {
                return _databaseContext.Tracks.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Track Update(Track track)
        {
            try
            {
                _databaseContext.Tracks.AddOrUpdate(track);
                return track;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(int trackId)
        {
            try
            {
                var existingTrack = ReadById(trackId);
                _databaseContext.Tracks.Remove(existingTrack);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
