using System.Collections.Generic;
using System.Linq;
using BLL.managers.interfaces;
using DAL.entities;
using DAL.unitOfWork;

namespace BLL.managers
{
    public class GenreManager : IManager<Genre>
    {
        private DisconnectedUnitOfWork _uow;

        public GenreManager()
        {
            _uow = new DisconnectedUnitOfWork();
        }

        public IEnumerable<Genre> ReadAll()
        {
            var genres = _uow.GenreRepository.ReadAll().ToList();

            return Utils.IsAny(genres) ? genres : null;
        }

        public Genre ReadById(int id)
        {
            return _uow.GenreRepository.ReadById(id);
        }

        public Genre Create(Genre genre)
        {
            return _uow.GenreRepository.Create(genre);
        }

        public Genre Update(Genre genre)
        {
            return _uow.GenreRepository.Update(genre);
        }

        public void Delete(int genreId)
        {
            _uow.GenreRepository.DeleteById(genreId);
        }
    }
}