namespace RecordingStudio.Domain;

public class Session
{

    public int Id { get; }
    public StudioRoom Room { get; }
    public DateRange TimeRange { get; }

    private readonly List<SessionParticipant> _participants = new List<SessionParticipant>();
    public IReadOnlyCollection<SessionParticipant> Participants => _participants;

    public Session(int id, StudioRoom room, DateRange timeRange)
    {
        if (id <= 0)
        {
            throw new ArgumentException("O ID tem que ser maior que 0");
        }

        Room = room ?? throw new ArgumentNullException(nameof(room));
        TimeRange = timeRange ?? throw new ArgumentNullException(nameof(timeRange));
        Id = id;
    }

    public void AddParticipant(
        Musician participant,
        SessionParticipant.InstrumentType instrument,
        SessionParticipant.SessionRole role,
        DateTime? arrivalTime = null)
    {
        if (participant is null)
        {
            throw new ArgumentNullException(nameof(participant));
        }

        if (_participants.Any(p => p.Participant.Id == participant.Id))
        {
            throw new InvalidOperationException($"O músico com ID {participant.Id} já está adicionado nesta sessão.");
        }

        var newParticipant = new SessionParticipant(participant, instrument, role, arrivalTime);
        _participants.Add(newParticipant);
    }

    public void EnsureHasAtLeastOneParticipant()
    {
        if (_participants.Count == 0)
        {
            throw new InvalidOperationException("A sessão deve ter pelo menos um músico participante.");
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Session other)
        {
            return false;
        }

        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

}