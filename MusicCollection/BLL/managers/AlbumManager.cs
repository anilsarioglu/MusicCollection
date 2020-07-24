using System.Collections.Generic;
using System.Linq;
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
            var albums = _uow.AlbumRepository.ReadAll().ToList();

            return Utils.IsAny(albums) ? albums : null;
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

        public void Delete(int albumId)
        {
            _uow.AlbumRepository.Delete(albumId);
        }
    }
}
