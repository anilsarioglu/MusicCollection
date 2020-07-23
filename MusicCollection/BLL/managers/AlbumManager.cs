using System.Collections.Generic;
using BLL.managers.interfaces;
using DAL.entities;
using DAL.unitOfWork;

namespace BLL.managers
{
    public class AlbumManager : IManager<Album>
    {
        private UnitOfWork _uow;

        public AlbumManager()
        {
            _uow = new UnitOfWork();
        }

        public IEnumerable<Album> ReadAll()
        {
            return _uow.AlbumRepository.ReadAll();
        }

        public Album ReadById(int id)
        {
           return _uow.AlbumRepository.ReadById(id);
        }

        public Album Create(Album album)
        {
            return _uow.AlbumRepository.Create(album);
        }

        public Album Update(Album album)
        {
            return _uow.AlbumRepository.Update(album);
        }

        public void Delete(Album album)
        {
            _uow.AlbumRepository.Delete(album);
        }
    }
}
