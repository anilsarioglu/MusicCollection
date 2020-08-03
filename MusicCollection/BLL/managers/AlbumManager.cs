using System;
using System.Collections.Generic;
using System.Linq;
using BLL.managers.interfaces;
using BLL.utilities;
using BLL.utilities.autoMapper;
using BLL.utilities.logger;
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
            try
            {
                var albums = Mapper.Map<IEnumerable<Album>, IEnumerable<AlbumDto>>(_uow.AlbumRepository.ReadAll().ToList());


                MyLogger.GetInstance().Info("Returned all albums");
                return Utils.IsAny(albums) ? albums : null;
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error("Couldn't return all albums", e.Message);
                throw new Exception(e.Message);
            }
        }

        public AlbumDto ReadById(int id)
        {
            try
            {
                var album = _uow.AlbumRepository.ReadById(id);

                MyLogger.GetInstance().Info($"Returned the album with id: {id}");
                return album == null ? null : Mapper.Map<Album, AlbumDto>(album);
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't return the album with id: {id}", e.Message);
                throw new Exception(e.Message);
            }
        }

        public AlbumDto Create(AlbumDto albumDto)
        {
            try
            {
                var album = Mapper.Map<AlbumDto, Album>(albumDto);
                _uow.AlbumRepository.Create(album);

                albumDto.Id = album.Id;

                MyLogger.GetInstance().Info($"Created the given album: {albumDto}");
                return albumDto;
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't create the given album: {albumDto}", e.Message);
                throw new Exception(e.Message);
            }
        }

        public AlbumDto Update(AlbumDto albumDto)
        {
            try
            {
                _uow.AlbumRepository.Update(Mapper.Map<AlbumDto, Album>(albumDto));

                MyLogger.GetInstance().Info($"Updated with the given album: {albumDto}");
                return albumDto;
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't update with the given album: {albumDto}", e.Message);
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _uow.AlbumRepository.DeleteById(id);
                MyLogger.GetInstance().Info($"Removed the album with id: {id}");
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't remove the album with id: {id}", e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}
