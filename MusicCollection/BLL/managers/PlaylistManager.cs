using System.Collections.Generic;
using System.Linq;
using BLL.managers.interfaces;
using DAL.entities;
using DAL.unitOfWork;

namespace BLL.managers
{
    public class PlaylistManager : IManager<Playlist>
    {
        private DisconnectedUnitOfWork _uow;

        public PlaylistManager(DisconnectedUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<Playlist> ReadAll()
        {
            var playlists = _uow.PlaylistRepository.ReadAll().ToList();

            return Utils.IsAny(playlists) ? playlists : null;
        }

        public Playlist ReadById(int id)
        {
            return _uow.PlaylistRepository.ReadById(id);
        }

        public Playlist Create(Playlist playlist)
        {
            return _uow.PlaylistRepository.Create(playlist);
        }

        public Playlist Update(Playlist playlist)
        {
            return _uow.PlaylistRepository.Update(playlist);
        }

        public void Delete(int playlistId)
        {
            _uow.PlaylistRepository.DeleteById(playlistId);
        }
    }
}