using System.Collections.Generic;
using System.Linq;
using BLL.autoMapper;
using BLL.managers.interfaces;
using DAL.entities;
using DAL.unitOfWork;
using Shared;

namespace BLL.managers
{
    public class PlaylistManager : IManager<PlaylistDto>
    {
        private DisconnectedUnitOfWork _uow;

        public PlaylistManager(DisconnectedUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<PlaylistDto> ReadAll()
        {
            var playlists = Mapper.Map<IEnumerable<Playlist>, IEnumerable<PlaylistDto>>(_uow.PlaylistRepository.ReadAll().ToList());

            return Utils.IsAny(playlists) ? playlists : null;
        }

        public PlaylistDto ReadById(int id)
        {
            var playlist = _uow.PlaylistRepository.ReadById(id);

            return playlist == null ? null : Mapper.Map<Playlist, PlaylistDto>(playlist);
        }

        public PlaylistDto Create(PlaylistDto playlistDto)
        {
            var playlist = Mapper.Map<PlaylistDto, Playlist>(playlistDto);
            _uow.PlaylistRepository.Create(playlist);

            playlistDto.Id = playlist.Id;

            return playlistDto;
        }

        public PlaylistDto Update(PlaylistDto playlistDto)
        {
            _uow.PlaylistRepository.Update(Mapper.Map<PlaylistDto, Playlist>(playlistDto));
            return playlistDto;
        }

        public void Delete(int playlistId)
        {
            _uow.PlaylistRepository.DeleteById(playlistId);
        }
    }
}