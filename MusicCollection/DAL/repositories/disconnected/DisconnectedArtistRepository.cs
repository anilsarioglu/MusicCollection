using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.entities;
using DAL.repositories.interfaces;

namespace DAL.repositories.disconnected
{
    public class DisconnectedArtistRepository : IDisconnectedRepository<Artist>
    {
        public Artist Create(Artist artist)
        {
            using (var context = new DatabaseContext())
            {
                var newArtist = context.Artists.Add(artist);
                return newArtist;
            }
        }

        public IEnumerable<Artist> ReadAll()
        {
            using (var context = new DatabaseContext())
            {
                return context.Artists.ToList();
            }
        }

        public Artist ReadById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Artists.Find(id);
            }
        }

        public Artist Update(Artist artist)
        {
            using (var context = new DatabaseContext())
            {
                context.Entry(artist).State = EntityState.Modified;
                context.SaveChanges();
                return artist;
            }
        }

        public void DeleteById(int artistId)
        {
            using (var context = new DatabaseContext())
            {
                var artist = context.Artists.Find(artistId);
                context.Entry(artist).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
