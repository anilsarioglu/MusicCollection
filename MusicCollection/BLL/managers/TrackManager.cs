using System.Collections.Generic;
using System.Linq;
using BLL.autoMapper;
using BLL.managers.interfaces;
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
            var tracks = Mapper.Map<IEnumerable<Track>, IEnumerable<TrackDto>>(_uow.TrackRepository.ReadAll().ToList());

            return Utils.IsAny(tracks) ? tracks : null;
        }

        public TrackDto ReadById(int id)
        {
            var track = _uow.TrackRepository.ReadById(id);

            return track == null ? null : Mapper.Map<Track, TrackDto>(track);
        }

        public TrackDto Create(TrackDto trackDto)
        {
            var track = Mapper.Map<TrackDto, Track>(trackDto);
            _uow.TrackRepository.Create(track);

            trackDto.Id = track.Id;

            return trackDto;
        }

        public TrackDto Update(TrackDto trackDto)
        {
            _uow.TrackRepository.Update(Mapper.Map<TrackDto, Track>(trackDto));
            return trackDto;
        }

        public void Delete(int trackId)
        {
            _uow.TrackRepository.DeleteById(trackId);
        }
    }
}