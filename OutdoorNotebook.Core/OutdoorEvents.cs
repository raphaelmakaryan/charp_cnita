namespace OutdoorNotebook.Core;

public class OutdoorEvents
{
    /**
     * Nom des événements
     */
    private string _name;

    /**
     * Lieu des événements
     */
    private string _lieu;

    /**
     * Description des événements, nullable
     */
    private readonly string? _description;

    private EventsDifficulty _difficulty;

    /**
     * Constructeur d'un event
     */
    public OutdoorEvents(string name, DateTime date, string lieu, int maxParticipants, int participantsActual,
        string? description, EventsDifficulty difficulty)
    {
        _name = name;
        Date1 = date;
        _lieu = lieu;
        MaxParticipants1 = maxParticipants;
        ParticipantsActual1 = participantsActual;
        _description = description;
        _difficulty = difficulty;
    }

    public string Name1
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    /**
     * Date des événements
     */
    public DateTime Date1 { get; set; }

    public string Lieu1
    {
        get => _lieu;
        set => _lieu = value ?? throw new ArgumentNullException(nameof(value));
    }

    public EventsDifficulty Difficulty
    {
        get => _difficulty;
        set => _difficulty = value;
    }

    /**
     * Nombre max de participants
     */
    public int MaxParticipants1 { get; set; }

    /**
     * Nombre actuel de participants
     */
    public int ParticipantsActual1 { get; set; }

    /**
     * Fonction pour retourner en propre les valeurs
     */
    public string DisplayData(OutdoorEvents outdoorEvents)
    {
        return "- " + outdoorEvents.Name1 + " — " + outdoorEvents.Lieu1 + " — " + outdoorEvents.Date1 + " — " +
               outdoorEvents.ParticipantsActual1 + "/" + outdoorEvents.MaxParticipants1 + " participants  — " +
               outdoorEvents.GetRemainingPlaces(outdoorEvents.ParticipantsActual1, outdoorEvents.MaxParticipants1) +
               " places restantes — " +
               outdoorEvents.IsFull(outdoorEvents.ParticipantsActual1, outdoorEvents.MaxParticipants1) + " — " +
               outdoorEvents._description + " — Difficulté : " + outdoorEvents._difficulty;
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