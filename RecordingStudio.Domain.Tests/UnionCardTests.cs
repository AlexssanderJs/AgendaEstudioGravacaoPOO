using RecordingStudio.Domain;

namespace RecordingStudio.Domain.Tests;

public class UnionCardTests
{
    [Fact]
    public void Constructor_FutureExpiration_Succeeds()
    {
        var expiration = DateTime.UtcNow.AddDays(30);

        var card = new UnionCard("123", expiration);

        Assert.Equal("123", card.Number);
        Assert.Equal(expiration, card.Expiration);
    }

    [Fact]
    public void Constructor_PastExpiration_ThrowsArgumentException()
    {
        var expiration = DateTime.UtcNow.AddDays(-1);

        Assert.Throws<ArgumentException>(() => new UnionCard("123", expiration));
    }

    [Fact]
    public void Constructor_EmptyNumber_ThrowsArgumentException()
    {
        var expiration = DateTime.UtcNow.AddDays(1);

        Assert.Throws<ArgumentException>(() => new UnionCard("", expiration));
    }
}
