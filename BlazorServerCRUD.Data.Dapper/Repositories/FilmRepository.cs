using BlazorServerCRUD.Model;
using Dapper;
using System.Data.SqlClient;

namespace BlazorServerCRUD.Data.Dapper.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly string _ConnectionString;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ConnectionString"></param>
        public FilmRepository(string ConnectionString) => _ConnectionString = ConnectionString;

        /// <summary>
        /// DbConnection
        /// </summary>
        /// <returns></returns>
        protected SqlConnection DbConnection() => new SqlConnection(_ConnectionString);

        public async Task<IEnumerable<Film>> GetAllFilms()
        {
            var db = DbConnection();
            var sql = @"SELECT Id, Title, Director, ReleaseDate FROM Films";
            return await db.QueryAsync<Film>(sql.ToString(), new {});            
        }

        public async Task<Film> GetFilm(int id)
        {
            var db = DbConnection();
            var sql = @"SELECT Id, Title, Director, ReleaseDate FROM Films WHERE Id = @id";
            return await db.QueryFirstOrDefaultAsync<Film>(sql.ToString(), new { id });
        }

        public async Task<bool> CreateFilm(Film film)
        {
            var db = DbConnection();
            var sql = @"INSERT INTO Films (Title, Director, ReleaseDate) VALUES (@Title, @Director, @ReleaseDate)";
            var result = await db.ExecuteAsync(sql.ToString(), new { film.Title, film.Director, film.ReleaseDate });             
            return result > 0;
        }

        public async Task<bool> UpdateFilm(Film film)
        {
            var db = DbConnection();
            var sql = @"UPDATE Films SET Title= @Title, Director = @Director, ReleaseDate = @ReleaseDate WHERE Id = @Id";
            var result = await db.ExecuteAsync(sql.ToString(), new { film.Title, film.Director, film.ReleaseDate, film.Id });
            return result > 0;
        }

        public async Task<bool> DeleteFilm(Film film)
        {
            var db = DbConnection();
            var sql = @"DELETE FROM Films WHERE Id = @Id";
            var result = await db.ExecuteAsync(sql.ToString(), new { film.Id });
            return result > 0;
        }
    }
}
