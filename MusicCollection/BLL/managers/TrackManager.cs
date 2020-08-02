using System.Collections.Generic;
using System.Linq;
using BLL.managers.interfaces;
using DAL.entities;
using DAL.unitOfWork;

namespace BLL.managers
{
    public class TrackManager : IManager<Track>
    {
        private DisconnectedUnitOfWork _uow;

        public TrackManager(DisconnectedUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<Track> ReadAll()
        {
            var tracks = _uow.TrackRepository.ReadAll().ToList();

            return Utils.IsAny(tracks) ? tracks : null;
        }

        public Track ReadById(int id)
        {
            return _uow.TrackRepository.ReadById(id);
        }

        public Track Create(Track track)
        {
            return _uow.TrackRepository.Create(track);
        }

        public Track Update(Track track)
        {
            return _uow.TrackRepository.Update(track);
        }

        public void Delete(int trackId)
        {
            _uow.TrackRepository.DeleteById(trackId);
        }
    }
}