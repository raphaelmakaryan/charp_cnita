namespace OutdoorNotebook.Core;

public class OutdoorEvents
{
    /**
     * ID des événements
     */
    private int _id;

    /**
     * Nom des événements
     */
    private string _name;

    /**
 * Date de l'évent
 */
    private readonly DateTime _date;

    /**
     * Lieu des événements
     */
    private string _place;

    /**
     * Description des événements, nullable
     */
    private string? _description;

    /**
     * Nombre max de participants
     */
    private readonly int _maxParticipants;

    /**
     * Nombre actuel de participants
     */
    private readonly int _participantsActual;

    /**
     * Niveau de difficulté
     */
    private EventsDifficulty _difficulty;

    /**
     * Durée de l'évent, en minutes
     */
    private int _duration;

    /**
     * Lieu de RDV
     */
    private string _meetingPlace;

    /**
     * Constructeur d'un event
     */
    public OutdoorEvents(int id, string name, DateTime date, string place, int maxParticipants, int participantsActual,
        string? description, EventsDifficulty difficulty, int duration, string meetingPlace)
    {
        _id = id;
        _name = name;
        _date = date;
        _place = place;
        _maxParticipants = maxParticipants;
        _participantsActual = participantsActual;
        _description = description;
        _difficulty = difficulty;
        _duration = duration;
        _meetingPlace = meetingPlace;
    }

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    /**
     * Date des événements
     */
    public DateTime Date
    {
        get => _date;
        set;
    }

    public string Place
    {
        get => _place;
        set => _place = value ?? throw new ArgumentNullException(nameof(value));
    }

    public EventsDifficulty Difficulty
    {
        get => _difficulty;
        set => _difficulty = value;
    }

    /**
     * Nombre max de participants
     */
    public int MaxParticipants
    {
        get => _maxParticipants;
        set;
    }

    /**
     * Nombre actuel de participants
     */
    public int ParticipantsActual
    {
        get => _participantsActual;
        set;
    }

    public string? Description
    {
        get => _description;
        set => _description = value;
    }

    public int Duration
    {
        get => _duration;
        set => _duration = value;
    }

    public string MeetingPlace
    {
        get => _meetingPlace;
        set => _meetingPlace = value ?? throw new ArgumentNullException(nameof(value));
    }

    /**
     * Fonction pour retourner en propre les valeurs
     */
    public static string DisplayData(OutdoorEvents outdoorEvents)
    {
        return outdoorEvents._id + " - " + outdoorEvents._name + " — " + outdoorEvents._place + " — " +
               outdoorEvents._date + " — " +
               outdoorEvents._participantsActual + "/" + outdoorEvents._maxParticipants + " participants  — " +
               outdoorEvents.GetRemainingPlaces(outdoorEvents._participantsActual, outdoorEvents._maxParticipants) +
               " places restantes — " +
               outdoorEvents.IsFull(outdoorEvents._participantsActual, outdoorEvents._maxParticipants) + " — " +
               outdoorEvents._description + " — Difficulté : " + outdoorEvents._difficulty + " — Durée : " +
               outdoorEvents._duration + " — RDV : " +
               outdoorEvents._meetingPlace;
    }


    /**
     * Fonction pour retourner le nombre de places manquantes
     */
    private int GetRemainingPlaces(int placeActuel, int placeMax)
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