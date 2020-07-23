using System.Collections.Generic;
using BLL.managers.interfaces;
using DAL.entities;
using DAL.unitOfWork;

namespace BLL.managers
{
    public class SongManager : IManager<Song>
    {
        private UnitOfWork _uow;

        public SongManager()
        {
            _uow = new UnitOfWork();
        }

        public IEnumerable<Song> ReadAll()
        {
            return _uow.SongRepository.ReadAll();
        }

        public Song ReadById(int id)
        {
            return _uow.SongRepository.ReadById(id);
        }

        public Song Create(Song song)
        {
            return _uow.SongRepository.Create(song);
        }

        public Song Update(Song song)
        {
            return _uow.SongRepository.Update(song);
        }

        public void Delete(int songId)
        {
            _uow.SongRepository.Delete(songId);
        }
    }
}