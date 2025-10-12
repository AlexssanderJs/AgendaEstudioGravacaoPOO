using System.Data;
using System.Runtime.InteropServices.Marshalling;

public class DateRange
{
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }

    public DateRange(DateTime start, DateTime end)
    {
        if (end < start)
        {
            throw new ArgumentException("Data final não pode ser menor que a data inicial.");
        }
        
        this.Start = start;
        this.End = end;

    }

    public static bool Overlaps(DateRange a, DateRange b)
    {
        return a.Start < b.End && b.Start < a.End;
    }
}