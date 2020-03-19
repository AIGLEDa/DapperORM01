using System;
using BeKindRewind;
using System.Data.SqlClient;


/// <summary>
/// version test
///3 package installé
//package installé Dapper et System.Configuration.ConfiguratinoManager et DataSQLClient
/// </summary>
namespace BeKindRewindConsole
{
    class Program
    {
        private const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\damien.aigle\Desktop\cours\cours sylvain labasse\mapping orm\sakila.mdf"";Integrated Security=True;Connect Timeout=30";

        static void Main(string[] args)
        {
            string valeurMenu;
            //Console.WriteLine("tapper comme le menu demande");


            do
            {


                Console.WriteLine("menu");
                Console.WriteLine("1 pour choisir la category");
                Console.WriteLine("Quitter pour quitter ");
                valeurMenu = Console.ReadLine();
                int.TryParse(valeurMenu, out int choixMenu);
                if (choixMenu == 1)
                {
                    CatalogRepository affiche = new CatalogRepository(connectionString);
                    // using (var affiche = new CatalogRepository(connectionStr))
                    //using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        Console.WriteLine("test");
                          foreach (var category in affiche.AllCategory)
                        {
                        Console.WriteLine($"({category.CategoryId}) {category.Name}  {category.LastUpdate}");
                        }
                    }

                }


                // utilisation Dapper
                //Exercice : remplir _allArtists avec un foreach

                /* foreach (var artist in liste)
                 {
                     _allArtists.Add(artist.IdArtist, artist);
                 }
                 */

            } while ("Quitter" != valeurMenu);

        }
    }
}
