using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.entities;
using DAL.repositories.interfaces;

namespace DAL.repositories.disconnected
{
    public class DisconnectedAlbumRepository : IDisconnectedRepository<Album>
    {
        public Album Create(Album album)
        {
            using (var context = new DatabaseContext())
            {
                var newAlbum = context.Albums.Add(album);
                context.SaveChanges();
                return newAlbum;
            }
        }

        public IEnumerable<Album> ReadAll()
        {
            using (var context = new DatabaseContext())
            {
                return context.Albums.ToList();
            }
        }

        public Album ReadById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Albums.Find(id);
            }
        }

        public Album Update(Album album)
        {
            using (var context = new DatabaseContext())
            {
                context.Entry(album).State = EntityState.Modified;
                context.SaveChanges();
                return album;
            }
        }

        public void DeleteById(int albumId)
        {
            using (var context = new DatabaseContext())
            {
                var album = context.Albums.Find(albumId);
                context.Entry(album).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
