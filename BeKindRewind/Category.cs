using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// version test
/// 3 package installé
//package installé Dapper et System.Configuration.ConfiguratinoManager et DataSQLClient
/// </summary>
namespace BeKindRewind
{
    public class Category
    {

        public DateTime LastUpdate { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }

        //private List<film_category> _film_categorys = new List<film_category>();

        public Category(int idcategory, string name, DateTime last_update)
        {
            LastUpdate = last_update;
            CategoryId = idcategory;
            Name = name;
        }

        public Category() //requis par Dapper
        {

        }
        //  public IEnumerable<Tract> Tracts => _tracts;
        /*
        public void AddTract(film_category t)
        {
            if (t.IdArtist != category_id)
            {
                throw new InvalidOperationException("Artist inconsistency while adding a track");
            }
            t.Artist = this;
            _film_categorys.Add(t);

        }
        //exercice : écrire une méthode AddTract(Tract t) qui ajoute une piste à la liste des pistes de cet artiste
        */

    }
}
