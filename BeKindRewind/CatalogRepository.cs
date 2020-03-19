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
        //private SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DapperConnection"].ToString());

        //public Dictionary<int, Category> _allCategory = new Dictionary<int, Category>();
        //  public Dictionary<int, Tract> _allTracts = new Dictionary<int, Tract>();
        private List<Category> _categories;
        


        public CatalogRepository(string connectionString)
        {
            _db = new SqlConnection(connectionString);
            _categories = new List<Category>();
            _categories.AddRange(_db.Query<Category>("SELECT category_id AS CategoryId, name, last_update AS LastUpdate FROM Category"));
            //string sqlrequete = "SELECT * FROM Category";

            //List<CatalogRepository> catalogRepository = new List<CatalogRepository>();

            // using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["CatalogRepositoryConnection"].ConnectionString))
            //using (_db)
            //   using (var connection = new SqlConnection())
            //  using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DapperConnection"].ToString()))



            // var orderDetails = _db.Query<Category>(sqlrequete).ToList();
            // db = new SqlConnection(connectionString);
            // _db.Open();


            //_db.Query<Category>(@"SELECT * FROM Category");
            //  catalogRepository = _db.Query<CatalogRepository>("Select * From Category").ToList();
            //_db.Close();




            //   }
            //return View(catalogRepository);


            //  using (var db = new SqlConnection(connectionString))//connexion à la base de données
            //{
            //db.Open();

            ////
            /*
            _db = new SqlConnection(connectionString);
            _db.Query<Category>(@"SELECT * FROM Category");




        }
        */
            ////
            /*public IEnumerable<Category> AllCategory => _allCategorys.Values;
             public IEnumerable<film_category> Alltracts => _db.Query<film_category>("SELECT [IdTrack], [Title], [Duration], [Path] FROM [Tract]");

            // public TimeSpan DurationTotal => TimeSpan.FromSeconds(Alltracts.Sum(tract => tract.Duration));
            public TimeSpan DurationTotal => TimeSpan.FromSeconds((int)_db.ExecuteScalar("SELECT SUM(Duration) FROM Tract"));

            public IEnumerable<Category> FindArtistByName(string search)
            {
                return _db.Query<Category>("SELECT * FROM Category WHERE Name LIKE @Search", new { Search = search + '%' });
            }

            public void Save(Category artist)
            {
                if (artist.category_id == 0)
                { //insérer
                    var sql = "INSERT INTO Artist(Name) VALUES(@Name); SELECT CAST(SCOPE_IDENTITY() as int)";
                    var returnId = _db.ExecuteScalar<int>(sql, artist);
                    artist.category_id = returnId;
                    _allArtists.Add(artist.category_id, artist);

                }
                else
                {//mise à jour (update
                    _db.Execute("UPDATE Artist SET Name=@Name WHERE IdArtist=@IdArtist", artist);
                }

            }

            void RemoveArtist(Category artist)
            {//effacer
                _db.Execute("DELETE FROM Artist WHERE IdArtist=@IdArtist", artist);
                _allArtists.Remove(artist.category_id);
            }

        */



        }
        public void Dispose()
        {
            _db.Dispose();
        }
        public IEnumerable<Category> AllCategory => _categories;

    }
}
