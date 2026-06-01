// See https://aka.ms/new-console-template for more information

using OutdoorNotebook.Console.Models;

//Console.WriteLine("Hello, World!");

/*
// Variable pour temps, je prend la date d'aujourd'hui, et je fais -1
DateTime dateTimeSortiePasse = DateTime.Today.AddDays(-1);
// je declare un event avec les parametres
OutdoorEvents sortiePasse = new OutdoorEvents("Randonnée au Parmelan", dateTimeSortiePasse, "Annecy", 12, 3, null);
// j'affiche dans la console
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
*/

var events = new List<OutdoorEvents>(new OutdoorEvents[]
{
    new OutdoorEvents("Randonnée au Parmelan", DateTime.Today.AddDays(-1), "Annecy", 12, 3, null),
    new OutdoorEvents("Sortie vélo autour du lac", DateTime.Today.AddDays(+2), "Annecy", 8, 8, null),
    new OutdoorEvents("Kayak", DateTime.Today.AddDays(+10), "Cran-Gevrier", 20, 5, null),
    new OutdoorEvents("Jogging", DateTime.Today.AddDays(+1), "Annecy", 12, 12, null),
    new OutdoorEvents("Canoe", DateTime.Today.AddDays(+5), "Annecy", 12, 0, "")
});

foreach (var outdoorEventse in events)
{
    Console.WriteLine(outdoorEventse.DisplayData(outdoorEventse));
}