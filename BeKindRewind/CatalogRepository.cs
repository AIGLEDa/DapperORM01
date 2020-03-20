using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Configuration;


/// <summary>
//version test
///3 package installé
//package installé Dapper et System.Configuration.ConfiguratinoManager et DataSQLClient
/// </summary>
namespace BeKindRewind
{
    public class CatalogRepository : IDisposable
    {


        private SqlConnection _db;
        private List<Category> _categories;
        private List<Film> _films;

        public IEnumerable<Film> GetFilmsByCategory(Category category)
        {

            _films = new List<Film>();
            // _films.AddRange(_db.Query<Film>("SELECT * FROM film_category INNER JOIN Category ON film_category.category_id = Category.caterogy_id"));
            return (_db.Query<Film>(@"SELECT film.film_id AS FilmId , film.title AS Title FROM film INNER JOIN film_category ON film_category.film_id = film.film_id WHERE film_category.category_id = @CategoryId", category));
            
        }

        public CatalogRepository(string connectionString)
        {
            _db = new SqlConnection(connectionString);
            _categories = new List<Category>();
            _categories.AddRange(_db.Query<Category>("SELECT category_id AS CategoryId, name, last_update AS LastUpdate FROM Category"));

        }
        public void Dispose()
        {
            _db.Dispose();
        }
        public IEnumerable<Category> AllCategory => _categories;

    }
}
