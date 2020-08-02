using System.Collections.Generic;
using System.Linq;
using BLL.managers.interfaces;
using DAL.entities;
using DAL.unitOfWork;

namespace BLL.managers
{
    public class ArtistManager : IManager<Artist>
    {
        private DisconnectedUnitOfWork _uow;

        public ArtistManager()
        {
            _uow = new DisconnectedUnitOfWork();
        }

        public IEnumerable<Artist> ReadAll()
        {
            var artists = _uow.ArtistRepository.ReadAll().ToList();

            return Utils.IsAny(artists) ? artists : null;
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
            _uow.ArtistRepository.DeleteById(artistId);
        }
    }
}