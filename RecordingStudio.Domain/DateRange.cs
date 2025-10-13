namespace RecordingStudio.Domain;

public class DateRange
{
    public DateTime Start { get; }
    public DateTime End { get; }

    public DateRange(DateTime start, DateTime end)
    {
        if (end <= start)
        {
            throw new ArgumentException("Data final deve ser maior que a data inicial.");
        }

        this.Start = start;
        this.End = end;

    }

    public static bool Overlaps(DateRange a, DateRange b)
    {
        if (a is null)
        {
            throw new ArgumentNullException(nameof(a));
        }

        if (b is null)
        {
            throw new ArgumentNullException(nameof(b));
        }

        return a.Start < b.End && b.Start < a.End;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not DateRange other)
        {
            return false;
        }

        return Start == other.Start && End == other.End;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Start, End);
    }

    public override string ToString()
    {
        return $"DateRange {{ Start = {Start:O}, End = {End:O} }}";
    }
}