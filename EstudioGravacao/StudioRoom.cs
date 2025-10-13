

public class StudioRoom
{
    public int Id { get;}
    public string Name { get;}

    private readonly List<Session> _sessions = new List<Session>();
    public IReadOnlyCollection<Session> Sessions => _sessions;

    public StudioRoom(int id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Nome não pode ser nulo.");
        }

        if (id <= 0)
        {
            throw new ArgumentException("Id tem que ser maior que zero.");
        }
        this.Id = id;
        this.Name = name;
    }

    public void Schedule(Session novaSessao)
    {
        if (novaSessao is null)
        {
            throw new ArgumentNullException(nameof(novaSessao));
        }

        if (!ReferenceEquals(novaSessao.Room, this))
        {
            throw new InvalidOperationException("A sessão deve pertencer a esta sala de estúdio.");
        }

        if (_sessions.Any(sessaoExistente => DateRange.Overlaps(sessaoExistente.TimeRange, novaSessao.TimeRange)))
        {
            throw new InvalidOperationException("Ja existe uma sessão agendada que colide com o horario solicitado");
        }

        _sessions.Add(novaSessao);
    }

    public void Cancel(int sessionId)
    {
        Session? sessionParaRemover = _sessions.FirstOrDefault(s => s.Id == sessionId);

        if (sessionParaRemover is null)
        {
            throw new ArgumentException($"A sessao com ID: {sessionId} não encontrada nesta sala");
        }

        _sessions.Remove(sessionParaRemover);

    }

     public override bool Equals(object? obj)
    {
        if (obj is not StudioRoom other)
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