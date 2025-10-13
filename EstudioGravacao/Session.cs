using System.ComponentModel;
using System.Diagnostics.Metrics;

public class Session
{
    internal static bool any;

    public int Id { get; }
    public StudioRoom Room { get; }
    public DateRange TimeRange { get;  }

    private readonly List<SessionParticipant> _participants = new List<SessionParticipant>();
    public IReadOnlyCollection<SessionParticipant> Participants => _participants;

    public Session(int id, StudioRoom room, DateRange timerange)
    {
        if (id <= 0)
        {
            throw new ArgumentException("O ID tem que ser maior que 0");
        }

        if (room is null)
        {
            throw new ArgumentException("A sessão deve ter uma sala (StudioRoom)");
        }

        if (timerange is null)
        {
            throw new ArgumentException("A sessão deve ter intervalo de tempo definido");
        }

        this.Id = id;
        this.Room = room;
        this.TimeRange = timerange;
    }

    public void AddParticipant(Musician participant, SessionParticipant.InstrumentType instrument, SessionParticipant.SessionRole role)
    {
        if (_participants.Any(p => p.Participant.Id == participant.Id))
        {
            throw new InvalidOperationException($"O músico com ID {participant.Id} já está adicionado nesta sessão.");
        }

        var newParticipant = new SessionParticipant(participant, instrument, role);
        _participants.Add(newParticipant);
    }

    public void EnsureHasAtLeastOneParticipant()
    {
        if(_participants.Count == 0)
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