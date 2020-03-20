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
    public class Film
    {

        public int FilmId { get; set; }
        public string Title { get; set; }

        public Film(int film_id, string title)
        {
            FilmId = film_id;
            Title = title;
        }

        public Film()
        {

        }



    }
}
