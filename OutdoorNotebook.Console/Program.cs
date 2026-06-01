// See https://aka.ms/new-console-template for more information

using OutdoorNotebook.Console.Models;

Tools tools = new Tools();

/**
 * EXERCICE DE 1 A 1.7

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

/**
 * EXERCICE 1.7
*/
var eventsEx17 = new List<OutdoorEvents>(new OutdoorEvents[]
{
    new OutdoorEvents("Randonnée au Parmelan", DateTime.Today.AddDays(-1), "Annecy", 12, 3, null),
    new OutdoorEvents("Sortie vélo autour du lac", DateTime.Today.AddDays(+2), "Annecy", 8, 8, null),
    new OutdoorEvents("Kayak", DateTime.Today.AddDays(+10), "Cran-Gevrier", 20, 5, null),
    new OutdoorEvents("Jogging", DateTime.Today.AddDays(+1), "Annecy", 12, 12, null),
    new OutdoorEvents("Canoe", DateTime.Today.AddDays(+5), "Annecy", 12, 0, "")
});

foreach (var outdoorEventse in eventsEx17)
{
    Console.WriteLine(outdoorEventse.DisplayData(outdoorEventse));
}

Console.WriteLine(tools.separation());

/**
 * Exercice 1.8
 */
var allEvents = new OutdoorEvents[]
{
    new OutdoorEvents("Randonnée au Parmelan", DateTime.Today.AddDays(-1), "Annecy", 12, 3, null),
    new OutdoorEvents("Sortie vélo autour du lac", DateTime.Today.AddDays(+2), "Annecy", 8, 8, null),
    new OutdoorEvents("Kayak", DateTime.Today.AddDays(+10), "Cran-Gevrier", 20, 5, null),
    new OutdoorEvents("Jogging", DateTime.Today.AddDays(+1), "Annecy", 12, 12, null),
    new OutdoorEvents("Canoe", DateTime.Today.AddDays(+5), "Annecy", 12, 0, "")
};

/**
 * Besoin 1
 */
var sortieAVenir = from events in allEvents where events.Date1 >= DateTime.Today select events;
foreach (var events in sortieAVenir)
{
    Console.WriteLine(events.DisplayData(events));
}

Console.WriteLine(tools.separation());

/**
 * Besoin 2
 */
var sortieComplete = from events in allEvents
    where events.IsFull(events.ParticipantsActual1, events.MaxParticipants1)
    select events;
foreach (var events in sortieComplete)
{
    Console.WriteLine(events.DisplayData(events));
}

Console.WriteLine(tools.separation());

/**
 * Besoin 3
 */

/**
 * - Je crée une "requete"
 * - qui va enuméré OutdoorEvents
 * - qui s'appelle "sortieTrié"
 * - on appelle la collection de allEvents auquel on va triéPar
 * - on défini la variable events
 * - qui va prendre le tri par rapport a la datz
 */
IEnumerable<OutdoorEvents> sortieTrié = allEvents.OrderBy(events => events.Date1);
foreach (var events in sortieTrié)
{
    Console.WriteLine(events.DisplayData(events));
}

Console.WriteLine(tools.separation());