using BlazorServerCRUD.Model;

namespace BlazorServerCRUD.UI.Interfaces
{
    public interface IFilmService
    {
        Task<IEnumerable<Film>> GetAll();
        Task<Film> Get(int id);        
        Task<bool> Save(Film film);
        Task<bool> Delete(Film film);
    }
}
