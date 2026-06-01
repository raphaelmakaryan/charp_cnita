// See https://aka.ms/new-console-template for more information

using OutdoorNotebook.Console.Models;

//Console.WriteLine("Hello, World!");

DateTime dateTimeSortiePasse = DateTime.Today.AddDays(-1);
OutdoorEvents sortiePasse = new OutdoorEvents("Randonnée au Parmelan", dateTimeSortiePasse, "Annecy", 12, 3, null);
Console.WriteLine(sortiePasse.DisplayData(sortiePasse));

DateTime dateTimeSortieFutur1 = DateTime.Today.AddDays(+2);
OutdoorEvents sortieFutur1 = new OutdoorEvents("Sortie vélo autour du lac", dateTimeSortieFutur1, "Annecy", 8, 8, null);
Console.WriteLine(sortieFutur1.DisplayData(sortieFutur1));

DateTime dateTimeSortieFutur2 = DateTime.Today.AddDays(+10);
OutdoorEvents sortieFutur2 = new OutdoorEvents("Kayak", dateTimeSortieFutur2, "Cran-Gevrier", 20, 5, null);
Console.WriteLine(sortieFutur2.DisplayData(sortieFutur2));

DateTime dateTimeSortieComplete = DateTime.Today.AddDays(+1);
OutdoorEvents sortieComplete = new OutdoorEvents("Jogging", dateTimeSortieComplete, "Annecy", 12, 12, null);
Console.WriteLine(sortieComplete.DisplayData(sortieComplete));

DateTime dateTimeSortieDispo = DateTime.Today.AddDays(+5);
OutdoorEvents sortieDispo = new OutdoorEvents("Canoe", dateTimeSortieDispo, "Annecy", 12, 0, "");
Console.WriteLine(sortieDispo.DisplayData(sortieDispo));