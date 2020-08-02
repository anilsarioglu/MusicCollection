using System.Collections.Generic;
using System.Linq;
using BLL.autoMapper;
using BLL.managers.interfaces;
using DAL.entities;
using DAL.unitOfWork;
using Shared;

namespace BLL.managers
{
    public class ArtistManager : IManager<ArtistDto>
    {
        private DisconnectedUnitOfWork _uow;

        public ArtistManager(DisconnectedUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<ArtistDto> ReadAll()
        {
            var artists = Mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistDto>>(_uow.ArtistRepository.ReadAll().ToList());

            return Utils.IsAny(artists) ? artists : null;
        }

        public ArtistDto ReadById(int id)
        {
            var artist = _uow.ArtistRepository.ReadById(id);
            return artist == null ? null : Mapper.Map<Artist, ArtistDto>(artist);
        }

        public ArtistDto Create(ArtistDto artistDto)
        {
            var artist = Mapper.Map<ArtistDto, Artist>(artistDto);
            _uow.ArtistRepository.Create(artist);

            artistDto.Id = artist.Id;

            return artistDto;
        }

        public ArtistDto Update(ArtistDto artistDto)
        {
            _uow.ArtistRepository.Update(Mapper.Map<ArtistDto, Artist>(artistDto));
            return artistDto;
        }

        public void Delete(int artistId)
        {
            _uow.ArtistRepository.DeleteById(artistId);
        }
    }
}