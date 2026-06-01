namespace OutdoorNotebook.Console.Models;

public class OutdoorEvents
{
    private string Name;
    private DateTime Date;
    private string Lieu;
    private int MaxParticipants;
    private int ParticipantsActual;
    private string? Description = null;

    public OutdoorEvents(string name, DateTime date, string lieu, int maxParticipants, int participantsActual, string? description)
    {
        Name = name;
        Date = date;
        Lieu = lieu;
        MaxParticipants = maxParticipants;
        ParticipantsActual = participantsActual;
    }

    public string Name1
    {
        get => Name;
        set => Name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public DateTime Date1
    {
        get => Date;
        set => Date = value;
    }

    public string Lieu1
    {
        get => Lieu;
        set => Lieu = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int MaxParticipants1
    {
        get => MaxParticipants;
        set => MaxParticipants = value;
    }

    public int ParticipantsActual1
    {
        get => ParticipantsActual;
        set => ParticipantsActual = value;
    }

    public string? Description1
    {
        get => Description;
        set => Description = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string DisplayData(OutdoorEvents outdoorEvents)
    {
        if (outdoorEvents.Description == null)
        {
            outdoorEvents.Description1 = "Aucune description";
        }
        return "- " + outdoorEvents.Name1 + " — " + outdoorEvents.Lieu1 + " — " + outdoorEvents.Date1 + " — " +
               outdoorEvents.ParticipantsActual1 + "/" + outdoorEvents.MaxParticipants1 + " participants  — " +
               outdoorEvents.GetRemainingPlaces(outdoorEvents.ParticipantsActual1, outdoorEvents.MaxParticipants1) +
               " places restantes — " +
               outdoorEvents.IsFull(outdoorEvents.ParticipantsActual1, outdoorEvents.MaxParticipants1) + " — " +
               outdoorEvents.Description;
    }


    public int GetRemainingPlaces(int placeActuel, int placeMax)
    {
        return placeMax - placeActuel;
    }

    public bool IsFull(int placeActuel, int placeMax)
    {
        return placeActuel >= placeMax;
    }
}