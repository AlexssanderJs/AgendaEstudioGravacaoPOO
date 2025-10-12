public class Session
{
    internal static bool any;

    public int Id { get; private set; }
    public StudioRoom Room { get; private set; }
    public DateRange TimeRange { get; private set; }

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

    internal static bool Any(Func<object, bool> value)
    {
        throw new NotImplementedException();
    }
}