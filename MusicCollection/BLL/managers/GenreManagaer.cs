using System.Collections.Generic;
using BLL.managers.interfaces;
using DAL.entities;
using DAL.unitOfWork;

namespace BLL.managers
{
    public class GenreManager : IManager<Genre>
    {
        private UnitOfWork _uow;

        public GenreManager()
        {
            _uow = new UnitOfWork();
        }

        public IEnumerable<Genre> ReadAll()
        {
            return _uow.GenreRepository.ReadAll();
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
            _uow.GenreRepository.Delete(genreId);
        }
    }
}