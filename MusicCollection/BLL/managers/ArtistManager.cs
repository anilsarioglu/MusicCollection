using System;
using System.Collections.Generic;
using System.Linq;
using BLL.managers.interfaces;
using BLL.utilities;
using BLL.utilities.autoMapper;
using BLL.utilities.logger;
using DAL.unitOfWork;
using Domain;
using Shared;

namespace BLL.managers
{
    public class ArtistManager : IManager<ArtistDto>
    {
        private DisconnectedUnitOfWork _uow;

        //public ArtistManager(DisconnectedUnitOfWork uow)
        //{
        //    _uow = uow;
        //}

        public ArtistManager()
        {
            _uow = new DisconnectedUnitOfWork();
        }

        public IEnumerable<ArtistDto> ReadAll()
        {
            try
            {
                //var artists = Mapper.Map<List<Artist>, List<ArtistDto>>(_uow.ArtistRepository.ReadAll().ToList());
                var artists = Mapper.MapList<Artist, ArtistDto>(_uow.ArtistRepository.ReadAll().ToList());

                MyLogger.GetInstance().Info("Returned all artists");
                return Utils.IsAny(artists) ? artists : null;
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error("Couldn't return all artists", e.Message);
                throw new Exception(e.Message);
            }
        }

        public ArtistDto ReadById(int id)
        {
            try
            {
                var artist = _uow.ArtistRepository.ReadById(id);

                MyLogger.GetInstance().Info($"Returned the artist with id: {id}");
                return artist == null ? null : Mapper.Map<Artist, ArtistDto>(artist);
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't return the artist with id: {id}", e.Message);
                throw new Exception(e.Message);
            }
        }

        public ArtistDto Create(ArtistDto artistDto)
        {
            try
            {
                var artist = Mapper.Map<ArtistDto, Artist>(artistDto);
                _uow.ArtistRepository.Create(artist);

                artistDto.Id = artist.Id;

                MyLogger.GetInstance().Info($"Created the given artist: {artistDto}");
                return artistDto;
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't create the given artist: {artistDto}", e.Message);
                throw new Exception(e.Message);
            }
        }

        public ArtistDto Update(ArtistDto artistDto)
        {
            try
            {
                _uow.ArtistRepository.Update(Mapper.Map<ArtistDto, Artist>(artistDto));

                MyLogger.GetInstance().Info($"Updated with the given artist: {artistDto}");
                return artistDto;
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't update with the given artist: {artistDto}", e.Message);
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _uow.ArtistRepository.DeleteById(id);
                MyLogger.GetInstance().Info($"Removed the artist with id: {id}");
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't remove the artist with id: {id}", e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}
