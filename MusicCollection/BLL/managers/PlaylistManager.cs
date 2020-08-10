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
    public class PlaylistManager : IManager<PlaylistDto>
    {
        private DisconnectedUnitOfWork _uow;

        //public PlaylistManager(DisconnectedUnitOfWork uow)
        //{
        //    _uow = uow;
        //}

        public PlaylistManager()
        {
            _uow = new DisconnectedUnitOfWork();
        }

        public IEnumerable<PlaylistDto> ReadAll()
        {
            try
            {
                var playlists = Mapper.MapList<Playlist, PlaylistDto>(_uow.PlaylistRepository.ReadAll().ToList());


                MyLogger.GetInstance().Info("Returned all playlists");
                return Utils.IsAny(playlists) ? playlists : null;
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error("Couldn't return all playlists", e.Message);
                throw new Exception(e.Message);
            }
        }

        public PlaylistDto ReadById(int id)
        {
            try
            {
                var playlist = _uow.PlaylistRepository.ReadById(id);

                MyLogger.GetInstance().Info($"Returned the playlist with id: {id}");
                return playlist == null ? null : Mapper.Map<Playlist, PlaylistDto>(playlist);
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't return the playlist with id: {id}", e.Message);
                throw new Exception(e.Message);
            }
        }

        public PlaylistDto Create(PlaylistDto playlistDto)
        {
            try
            {
                var playlist = Mapper.Map<PlaylistDto, Playlist>(playlistDto);
                _uow.PlaylistRepository.Create(playlist);

                playlistDto.Id = playlist.Id;

                MyLogger.GetInstance().Info($"Created the given playlist: {playlistDto}");
                return playlistDto;
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't create the given playlist: {playlistDto}", e.Message);
                throw new Exception(e.Message);
            }
        }

        public PlaylistDto Update(PlaylistDto playlistDto)
        {
            try
            {
                _uow.PlaylistRepository.Update(Mapper.Map<PlaylistDto, Playlist>(playlistDto));

                MyLogger.GetInstance().Info($"Updated with the given playlist: {playlistDto}");
                return playlistDto;
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't update with the given playlist: {playlistDto}", e.Message);
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _uow.PlaylistRepository.DeleteById(id);
                MyLogger.GetInstance().Info($"Removed the playlist with id: {id}");
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't remove the playlist with id: {id}", e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}
