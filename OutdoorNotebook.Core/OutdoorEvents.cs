namespace OutdoorNotebook.Core;

public class OutdoorEvents
{
    /**
     * Nom des événements
     */
    private string _name;

    /**
 * Date de l'event
 */
    private DateTime _date;

    /**
     * Lieu des événements
     */
    private string _place;

    /**
     * Description des événements, nullable
     */
    private readonly string? _description;

    /**
     * Nombre max de participants
     */
    private int _maxParticipants;

    /**
     * Nombre actuel de participants
     */
    private int _participantsActual;

    /**
     * Niveau de difficulté
     */
    private EventsDifficulty _difficulty;

    /**
     * Durée de l'event, en minutes
     */
    private int _duration;

    /**
     * Lieu de RDV
     */
    private string _meetingPlace;

    /**
     * Constructeur d'un event
     */
    public OutdoorEvents(string name, DateTime date, string place, int maxParticipants, int participantsActual,
        string? description, EventsDifficulty difficulty, int duration, string meetingPlace)
    {
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

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    /**
     * Date des événements
     */
    public DateTime Date { get; set; }

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
    public int MaxParticipants { get; set; }

    /**
     * Nombre actuel de participants
     */
    public int ParticipantsActual { get; set; }

    public string? Description => _description;

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
    public string DisplayData(OutdoorEvents outdoorEvents)
    {
        return "- " + outdoorEvents.Name + " — " + outdoorEvents.Place + " — " + outdoorEvents.Date + " — " +
               outdoorEvents.ParticipantsActual + "/" + outdoorEvents.MaxParticipants + " participants  — " +
               outdoorEvents.GetRemainingPlaces(outdoorEvents.ParticipantsActual, outdoorEvents.MaxParticipants) +
               " places restantes — " +
               outdoorEvents.IsFull(outdoorEvents.ParticipantsActual, outdoorEvents.MaxParticipants) + " — " +
               outdoorEvents._description + " — Difficulté : " + outdoorEvents._difficulty + " — Durée : " +
               outdoorEvents.Duration + " — RDV : " +
               outdoorEvents.MeetingPlace;
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