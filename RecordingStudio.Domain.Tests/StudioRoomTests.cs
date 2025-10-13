using RecordingStudio.Domain;

namespace RecordingStudio.Domain.Tests;

public class StudioRoomTests
{
    [Fact]
    public void Schedule_NonOverlappingSessions_Succeeds()
    {
        var room = new StudioRoom(1, "Sala A");
        var morning = new Session(1, room, BuildRange(8));
        var afternoon = new Session(2, room, BuildRange(11));

        room.Schedule(morning);
        room.Schedule(afternoon);

        Assert.Equal(2, room.Sessions.Count);
    }

    [Fact]
    public void Schedule_OverlappingSessions_ThrowsInvalidOperationException()
    {
        var room = new StudioRoom(1, "Sala A");
        var first = new Session(1, room, BuildRange(8));
        var overlapping = new Session(2, room, BuildRange(9));

        room.Schedule(first);

        var ex = Assert.Throws<InvalidOperationException>(() => room.Schedule(overlapping));
        Assert.Contains("colide", ex.Message, StringComparison.OrdinalIgnoreCase);
    }

    private static DateRange BuildRange(int startHour)
    {
        var day = new DateTime(2025, 10, 13, 0, 0, 0, DateTimeKind.Utc);
        return new DateRange(day.AddHours(startHour), day.AddHours(startHour + 2));
    }
}
