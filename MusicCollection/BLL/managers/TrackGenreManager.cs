using System;
using System.Collections.Generic;
using System.Linq;
using BLL.utilities.autoMapper;
using BLL.managers.interfaces;
using BLL.utilities;
using BLL.utilities.logger;
using DAL.unitOfWork;
using Domain;
using Shared;

namespace BLL.Managers
{
    public class TrackGenreManager : IManager<TrackGenreDto>
    {
        private DisconnectedUnitOfWork _uow;

        //public TrackGenreManager(DisconnectedUnitOfWork uow)
        //{
        //    _uow = uow;
        //}

        public TrackGenreManager()
        {
            _uow = new DisconnectedUnitOfWork();
        }

        public IEnumerable<TrackGenreDto> ReadAll()
        {
            try
            {
                //var trackGenres = Mapper.Map<List<TrackGenre>, List<TrackGenreDto>>(_uow.TrackGenreRepository.ReadAll().ToList());
                
                var trackGenres = Mapper.MapList<TrackGenre, TrackGenreDto>(_uow.TrackGenreRepository.ReadAll().ToList());

                MyLogger.GetInstance().Info("Returned all trackGenres");
                return Utils.IsAny(trackGenres) ? trackGenres : null;
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error("Couldn't return all trackGenres", e.Message);
                throw new Exception(e.Message);
            }
        }

        public TrackGenreDto ReadById(int id)
        {
            try
            {
                var trackGenre = _uow.TrackGenreRepository.ReadById(id);

                MyLogger.GetInstance().Info($"Returned the trackGenre with id: {id}");
                return trackGenre == null ? null : Mapper.Map<TrackGenre, TrackGenreDto>(trackGenre);
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't return the trackGenre with id: {id}", e.Message);
                throw new Exception(e.Message);
            }
        }

        public TrackGenreDto Create(TrackGenreDto trackGenreDto)
        {
            try
            {
                var trackGenre = Mapper.Map<TrackGenreDto, TrackGenre>(trackGenreDto);
                _uow.TrackGenreRepository.Create(trackGenre);

                trackGenreDto.Id = trackGenre.Id;

                MyLogger.GetInstance().Info($"Created the given trackGenre: {trackGenreDto}");
                return trackGenreDto;
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't create the given trackGenre: {trackGenreDto}", e.Message);
                throw new Exception(e.Message);
            }
        }

        public TrackGenreDto Update(TrackGenreDto trackGenreDto)
        {
            try
            {
                _uow.TrackGenreRepository.Update(Mapper.Map<TrackGenreDto, TrackGenre>(trackGenreDto));

                MyLogger.GetInstance().Info($"Updated with the given trackGenre: {trackGenreDto}");
                return trackGenreDto;
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't update with the given trackGenre: {trackGenreDto}", e.Message);
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _uow.TrackGenreRepository.DeleteById(id);
                MyLogger.GetInstance().Info($"Removed the trackGenre with id: {id}");
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't remove the trackGenre with id: {id}", e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}
