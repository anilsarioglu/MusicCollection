using System.Collections.Generic;
using System.Linq;
using BLL.autoMapper;
using BLL.managers.interfaces;
using DAL.entities;
using DAL.unitOfWork;
using Shared;

namespace BLL.managers
{
    public class GenreManager : IManager<GenreDto>
    {
        private DisconnectedUnitOfWork _uow;

        public GenreManager(DisconnectedUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<GenreDto> ReadAll()
        {
            var genres = Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDto>>(_uow.GenreRepository.ReadAll().ToList());

            return Utils.IsAny(genres) ? genres : null;
        }

        public GenreDto ReadById(int id)
        {
            var genre = _uow.GenreRepository.ReadById(id);

            return genre == null ? null : Mapper.Map<Genre, GenreDto>(genre);
        }

        public GenreDto Create(GenreDto genreDto)
        {
            var genre = Mapper.Map<GenreDto, Genre>(genreDto);
            _uow.GenreRepository.Create(genre);

            genreDto.Id = genre.Id;

            return genreDto;
        }

        public GenreDto Update(GenreDto genreDto)
        {
            _uow.GenreRepository.Update(Mapper.Map<GenreDto, Genre>(genreDto));
            return genreDto;
        }

        public void Delete(int genreId)
        {
            _uow.GenreRepository.DeleteById(genreId);
        }
    }
}
