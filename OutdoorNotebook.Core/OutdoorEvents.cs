using System.Collections.ObjectModel;

namespace OutdoorNotebook.Console.Models;

public class OutdoorEvents
{
    /**
     * Nom de l'event
     */
    private string _name;

    /**
     * Date de l'event
     */
    private DateTime _date;

    /**
     * Lieu de l'event
     */
    private string _lieu;

    /**
     * Nombre max de participants
     */
    private int _maxParticipants;

    /**
     * Nombre actuel de participants
     */
    private int _participantsActual;

    /**
     * Description de l'event, nullable
     */
    private string? _description = null;

    /**
     * Constructeur d'un event
     */
    public OutdoorEvents(string name, DateTime date, string lieu, int maxParticipants, int participantsActual,
        string? description)
    {
        _name = name;
        _date = date;
        _lieu = lieu;
        _maxParticipants = maxParticipants;
        _participantsActual = participantsActual;
    }

    public string Name1
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public DateTime Date1
    {
        get => _date;
        set => _date = value;
    }

    public string Lieu1
    {
        get => _lieu;
        set => _lieu = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int MaxParticipants1
    {
        get => _maxParticipants;
        set => _maxParticipants = value;
    }

    public int ParticipantsActual1
    {
        get => _participantsActual;
        set => _participantsActual = value;
    }

    public string? Description1
    {
        get => _description;
        set => _description = value ?? throw new ArgumentNullException(nameof(value));
    }

    /**
     * Fonction pour retourner en propre les valeurs
     */
    public string DisplayData(OutdoorEvents outdoorEvents)
    {
        if (outdoorEvents._description == null)
        {
            outdoorEvents.Description1 = "Aucune description";
        }

        return "- " + outdoorEvents.Name1 + " — " + outdoorEvents.Lieu1 + " — " + outdoorEvents.Date1 + " — " +
               outdoorEvents.ParticipantsActual1 + "/" + outdoorEvents.MaxParticipants1 + " participants  — " +
               outdoorEvents.GetRemainingPlaces(outdoorEvents.ParticipantsActual1, outdoorEvents.MaxParticipants1) +
               " places restantes — " +
               outdoorEvents.IsFull(outdoorEvents.ParticipantsActual1, outdoorEvents.MaxParticipants1) + " — " +
               outdoorEvents._description;
    }


    /**
     * Fonction pour retourner le nombre de places manquantes
     */
    public int GetRemainingPlaces(int placeActuel, int placeMax)
    {
        return placeMax - placeActuel;
    }

    /**
     * Fonction pour retourner si oui ou non c'est full
     */
    public bool IsFull(int placeActuel, int placeMax)
    {
        return placeActuel >= placeMax;
    }
}