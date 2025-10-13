using RecordingStudio.Domain;

namespace RecordingStudio.Domain.Tests;

public class SessionTests
{
    [Fact]
    public void AddParticipant_SameMusicianTwice_ThrowsInvalidOperationException()
    {
        var room = new StudioRoom(1, "Sala A");
        var session = new Session(1, room, BuildRange(hours: 2));
        var musician = new Musician(1, "Ana Silva", stageName: null);

        session.AddParticipant(musician, SessionParticipant.InstrumentType.Guitar, SessionParticipant.SessionRole.Lead);

        Assert.Throws<InvalidOperationException>(() =>
            session.AddParticipant(musician, SessionParticipant.InstrumentType.Guitar, SessionParticipant.SessionRole.Support));
    }

    [Fact]
    public void EnsureHasAtLeastOneParticipant_WithoutParticipants_ThrowsInvalidOperationException()
    {
        var room = new StudioRoom(1, "Sala A");
        var session = new Session(1, room, BuildRange(hours: 2));

        Assert.Throws<InvalidOperationException>(() => session.EnsureHasAtLeastOneParticipant());
    }

    private static DateRange BuildRange(int hours)
    {
        var start = new DateTime(2025, 10, 13, 8, 0, 0, DateTimeKind.Utc);
        return new DateRange(start, start.AddHours(hours));
    }
}
