using System.Collections.Generic;
using System.Linq;
using BLL.autoMapper;
using BLL.managers.interfaces;
using DAL.entities;
using DAL.unitOfWork;
using Shared;

namespace BLL.managers
{
    public class AlbumManager : IManager<AlbumDto>
    {
        private DisconnectedUnitOfWork _uow;

        public AlbumManager(DisconnectedUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<AlbumDto> ReadAll()
        {
            var albums = Mapper.Map<IEnumerable<Album>, IEnumerable<AlbumDto>>(_uow.AlbumRepository.ReadAll().ToList());

            return Utils.IsAny(albums) ? albums : null;
        }

        public AlbumDto ReadById(int id)
        {
            var album = _uow.AlbumRepository.ReadById(id);

            return album == null ? null : Mapper.Map<Album, AlbumDto>(album);
        }

        public AlbumDto Create(AlbumDto albumDto)
        {
            var album = Mapper.Map<AlbumDto, Album>(albumDto);
            _uow.AlbumRepository.Create(album);

            albumDto.Id = album.Id;

            return albumDto;
        }

        public AlbumDto Update(AlbumDto albumDto)
        {
            _uow.AlbumRepository.Update(Mapper.Map<AlbumDto, Album>(albumDto));
            return albumDto;
        }

        public void Delete(int albumId)
        {
            _uow.AlbumRepository.DeleteById(albumId);
        }
    }
}
