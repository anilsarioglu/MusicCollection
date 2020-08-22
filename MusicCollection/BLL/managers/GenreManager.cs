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
    public class GenreManager : IManager<GenreDto>
    {
        private DisconnectedUnitOfWork _uow;

        //public GenreManager(DisconnectedUnitOfWork uow)
        //{
        //    _uow = uow;
        //}

        public GenreManager()
        {
            _uow = new DisconnectedUnitOfWork();
        }

        public IEnumerable<GenreDto> ReadAll()
        {
            try
            {
                var genres = Mapper.MapList<Genre, GenreDto>(_uow.GenreRepository.ReadAll().ToList());


                MyLogger.GetInstance().Info("Returned all genres");
                return Utils.IsAny(genres) ? genres : null;
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error("Couldn't return all genres", e.Message);
                throw new Exception(e.Message);
            }
        }

        public GenreDto ReadById(int id)
        {
            try
            {
                var genre = _uow.GenreRepository.ReadById(id);

                MyLogger.GetInstance().Info($"Returned the genre with id: {id}");
                return genre == null ? null : Mapper.Map<Genre, GenreDto>(genre);
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't return the genre with id: {id}", e.Message);
                throw new Exception(e.Message);
            }
        }

        public GenreDto Create(GenreDto genreDto)
        {
            try
            {
                var genre = Mapper.Map<GenreDto, Genre>(genreDto);
                _uow.GenreRepository.Create(genre);

                genreDto.Id = genre.Id;

                MyLogger.GetInstance().Info($"Created the given genre: {genreDto}");
                return genreDto;
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't create the given genre: {genreDto}", e.Message);
                throw new Exception(e.Message);
            }
        }

        public GenreDto Update(GenreDto genreDto)
        {
            try
            {
                _uow.GenreRepository.Update(Mapper.Map<GenreDto, Genre>(genreDto));

                MyLogger.GetInstance().Info($"Updated with the given genre: {genreDto}");
                return genreDto;
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't update with the given genre: {genreDto}", e.Message);
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _uow.GenreRepository.DeleteById(id);
                MyLogger.GetInstance().Info($"Removed the genre with id: {id}");
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error($"Couldn't remove the genre with id: {id}", e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}
