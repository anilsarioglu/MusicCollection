using System.Collections.Generic;
using BLL.managers.interfaces;
using DAL.entities;
using DAL.unitOfWork;

namespace BLL.managers
{
    public class ArtistManager : IManager<Artist>
    {
        private UnitOfWork _uow;

        public ArtistManager()
        {
            _uow = new UnitOfWork();
        }

        public IEnumerable<Artist> ReadAll()
        {
            return _uow.ArtistRepository.ReadAll();
        }

        public Artist ReadById(int id)
        {
            return _uow.ArtistRepository.ReadById(id);
        }

        public Artist Create(Artist artist)
        {
            return _uow.ArtistRepository.Create(artist);
        }

        public Artist Update(Artist artist)
        {
            return _uow.ArtistRepository.Update(artist);
        }

        public void Delete(int artistId)
        {
            _uow.ArtistRepository.Delete(artistId);
        }
    }
}