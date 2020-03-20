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



        public Category(int idcategory, string name, DateTime last_update)
        {
            LastUpdate = last_update;
            CategoryId = idcategory;
            Name = name;
        }

        public Category() //requis par Dapper
        {

        }

    }
}
