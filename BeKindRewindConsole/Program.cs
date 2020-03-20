using System;
using BeKindRewind;
using System.Data.SqlClient;
using System.Linq;

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
            bool ended = false;
            string valeurMenu;

            int index = 0;


            do
            {


                Console.WriteLine("menu");
                Console.WriteLine("1 pour choisir la category");
                Console.WriteLine("Quitter pour quitter ");
                valeurMenu = Console.ReadLine();
                if(int.TryParse(valeurMenu, out int choixMenu))
                {
                    Console.WriteLine($"votre choix est : {choixMenu}");
                }
                else
                {
                    Console.WriteLine("veuillez tapper à nouveau. Votre choix ne fait pas" +
                        " parti du menu");
                }
                if (choixMenu == 1)
                {
                    try
                    {
                        CatalogRepository affiche = new CatalogRepository(connectionString);
                        {

                            foreach (var category in affiche.AllCategory)
                            {
                                Console.WriteLine($"({category.CategoryId}) {++index} {category.Name}  {category.LastUpdate}");

                            
                            }

                            Console.WriteLine("Veuillez choisir une catégorie");
                            string MenuChoice = Console.ReadLine();
                            if(int.TryParse(MenuChoice, out int ChoiceInTheMenu))
                            {
                                Console.WriteLine($"Your choice is : {ChoiceInTheMenu}");
                                if(index == ChoiceInTheMenu)
                                {
                                    ended = true;
                                    
                                    Console.WriteLine("");
                                }
                                else if(1<= ChoiceInTheMenu && ChoiceInTheMenu < index)
                                {
                                    var categoryName = affiche.AllCategory.ElementAt(ChoiceInTheMenu - 1).Name;
                                    Console.WriteLine($"vous avez choisi {categoryName}");
                                    foreach (var film in affiche.GetFilmsByCategory(affiche.AllCategory.ElementAt(ChoiceInTheMenu - 1)).Take(10))
                                    {
                                        Console.WriteLine($"l'id du filme est : {film.FilmId} et son titre est : {film.Title}");
                                    }
                                }


                            }
                            else
                            {
                                Console.WriteLine($"There is a issue in the choice in the menu");
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        Console.Error.WriteLine($"Database connection: {e.Message}");
                    }

                }


            } while ("Quitter" != valeurMenu);

        }
    }
}
