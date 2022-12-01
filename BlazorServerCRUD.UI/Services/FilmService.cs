using BlazorServerCRUD.Data.Dapper.Repositories;
using BlazorServerCRUD.Model;
using BlazorServerCRUD.UI.Data;
using BlazorServerCRUD.UI.Interfaces;

namespace BlazorServerCRUD.UI.Services
{
    public class FilmService : IFilmService
    {
        private readonly SqlConfiguration _configuration;

        private IFilmRepository _filmRepository;

        public FilmService(SqlConfiguration configuration)
        {
            _configuration = configuration;
            _filmRepository= new FilmRepository(_configuration.ConnectionString);
        }   

        public Task<IEnumerable<Film>> GetAll() => _filmRepository.GetAllFilms();

        public Task<Film> Get(int id) => _filmRepository.GetFilm(id);

        public Task<bool> Save(Film film) => film.Id == 0 ? _filmRepository.CreateFilm(film) : _filmRepository.UpdateFilm(film);

        public Task<bool> Delete(Film film) => _filmRepository.DeleteFilm(film);
    }
}
