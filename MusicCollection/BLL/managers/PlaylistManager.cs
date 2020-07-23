using System.Collections.Generic;
using BLL.managers.interfaces;
using DAL.entities;
using DAL.unitOfWork;

namespace BLL.managers
{
    public class PlaylistManager : IManager<Playlist>
    {
        private UnitOfWork _uow;

        public PlaylistManager()
        {
            _uow = new UnitOfWork();
        }

        public IEnumerable<Playlist> ReadAll()
        {
            return _uow.PlaylistRepository.ReadAll();
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
            _uow.PlaylistRepository.Delete(playlistId);
        }
    }
}