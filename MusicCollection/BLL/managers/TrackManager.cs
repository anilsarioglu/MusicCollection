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
    public class TrackManager : IManager<TrackDto>
    {
        private DisconnectedUnitOfWork _uow;

        public TrackManager(DisconnectedUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<TrackDto> ReadAll()
        {
            try
            {
                var tracks = Mapper.Map<IEnumerable<Track>, IEnumerable<TrackDto>>(_uow.TrackRepository.ReadAll().ToList());


                MyLogger.GetInstance().Info("Returned all tracks");
                return Utils.IsAny(tracks) ? tracks : null;
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error("Couldn't return all tracks", e.Message);
                throw new Exception(e.Message);
            }
        }

        public TrackDto ReadById(int id)
        {
            try
            {
                var track = _uow.TrackRepository.ReadById(id);

                MyLogger.GetInstance().Info($"Returned the track with id: {id}");
                return track == null ? null : Mapper.Map<Track, TrackDto>(track);
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't return the track with id: {id}", e.Message);
                throw new Exception(e.Message);
            }
        }

        public TrackDto Create(TrackDto trackDto)
        {
            try
            {
                var track = Mapper.Map<TrackDto, Track>(trackDto);
                _uow.TrackRepository.Create(track);

                trackDto.Id = track.Id;

                MyLogger.GetInstance().Info($"Created the given track: {trackDto}");
                return trackDto;
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't create the given track: {trackDto}", e.Message);
                throw new Exception(e.Message);
            }
        }

        public TrackDto Update(TrackDto trackDto)
        {
            try
            {
                _uow.TrackRepository.Update(Mapper.Map<TrackDto, Track>(trackDto));

                MyLogger.GetInstance().Info($"Updated with the given track: {trackDto}");
                return trackDto;
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't update with the given track: {trackDto}", e.Message);
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _uow.TrackRepository.DeleteById(id);
                MyLogger.GetInstance().Info($"Removed the track with id: {id}");
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't remove the track with id: {id}", e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}
