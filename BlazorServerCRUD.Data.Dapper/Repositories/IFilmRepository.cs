using BlazorServerCRUD.Model;

namespace BlazorServerCRUD.Data.Dapper.Repositories
{
    public interface IFilmRepository
    {
        Task<IEnumerable<Film>> GetAllFilms();
        Task<Film> GetFilm(int id);
        Task<bool> CreateFilm(Film film);
        Task<bool> UpdateFilm(Film film);
        Task<bool> DeleteFilm(Film film);
    }
}
