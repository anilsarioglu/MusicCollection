using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.repositories.interfaces;
using Domain;

namespace DAL.repositories
{
    public class DisconnectedPlaylistRepository : IDisconnectedRepository<Playlist>
    {
        public Playlist Create(Playlist playlist)
        {
            using (var context = new DatabaseContext())
            {
                var newPlaylist = context.Playlists.Add(playlist);
                context.SaveChanges();
                return newPlaylist;
            }
        }

        public IEnumerable<Playlist> ReadAll()
        {
            using (var context = new DatabaseContext())
            {
                return context.Playlists.ToList();
            }
        }

        public Playlist ReadById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Playlists.Find(id);
            }
        }

        public Playlist Update(Playlist playlist)
        {
            using (var context = new DatabaseContext())
            {
                context.Entry(playlist).State = EntityState.Modified;
                context.SaveChanges();
                return playlist;
            }
        }

        public void DeleteById(int playlistId)
        {
            using (var context = new DatabaseContext())
            {
                var playlist = context.Playlists.Find(playlistId);
                context.Entry(playlist).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
