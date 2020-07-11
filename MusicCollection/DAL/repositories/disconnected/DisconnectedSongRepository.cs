using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.entities;
using DAL.repositories.interfaces;

namespace DAL.repositories.disconnected
{
    public class DisconnectedSongRepository : IDisconnectedRepository<Song>
    {
        public Song Create(Song song)
        {
            using (var context = new DatabaseContext())
            {
                return context.Songs.Add(song);
            }
        }

        public IEnumerable<Song> ReadAll()
        {
            using (var context = new DatabaseContext())
            {
                return context.Songs.ToList();
            }
        }

        public Song ReadById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Songs.Find(id);
            }
        }

        public Song Update(Song song)
        {
            using (var context = new DatabaseContext())
            {
                context.Entry(song).State = EntityState.Modified;
                return song;
            }
        }

        public void DeleteById(int songId)
        {
            using (var context = new DatabaseContext())
            {
                var song = context.Songs.Find(songId);
                context.Entry(song).State = EntityState.Deleted;
            }
        }
    }
}
