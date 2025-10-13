using RecordingStudio.Domain;

namespace RecordingStudio.Domain.Tests;

public class DateRangeTests
{
    [Fact]
    public void Constructor_ValidRange_Succeeds()
    {
        var start = new DateTime(2025, 10, 13, 9, 0, 0, DateTimeKind.Utc);
        var end = start.AddHours(2);

        var range = new DateRange(start, end);

        Assert.Equal(start, range.Start);
        Assert.Equal(end, range.End);
    }

    [Theory]
    [InlineData(2025, 10, 13, 9, 0, 0, 2025, 10, 13, 9, 0, 0)]
    [InlineData(2025, 10, 13, 10, 0, 0, 2025, 10, 13, 9, 0, 0)]
    public void Constructor_InvalidRange_ThrowsArgumentException(
        int startYear,
        int startMonth,
        int startDay,
        int startHour,
        int startMinute,
        int startSecond,
        int endYear,
        int endMonth,
        int endDay,
        int endHour,
        int endMinute,
        int endSecond)
    {
        var start = new DateTime(startYear, startMonth, startDay, startHour, startMinute, startSecond, DateTimeKind.Utc);
        var end = new DateTime(endYear, endMonth, endDay, endHour, endMinute, endSecond, DateTimeKind.Utc);

        Assert.Throws<ArgumentException>(() => new DateRange(start, end));
    }

    [Theory]
    [InlineData(8, 10, 10, 12, false)]
    [InlineData(8, 11, 10, 12, true)]
    [InlineData(8, 12, 9, 10, true)]
    [InlineData(8, 9, 9, 10, false)]
    public void Overlaps_Scenarios_ReturnsExpectedResult(int startHourA, int endHourA, int startHourB, int endHourB, bool expected)
    {
        var day = new DateTime(2025, 10, 13, 0, 0, 0, DateTimeKind.Utc);
        var rangeA = new DateRange(day.AddHours(startHourA), day.AddHours(endHourA));
        var rangeB = new DateRange(day.AddHours(startHourB), day.AddHours(endHourB));

        var result = DateRange.Overlaps(rangeA, rangeB);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Overlaps_NullArgument_Throws()
    {
        var day = new DateTime(2025, 10, 13, 0, 0, 0, DateTimeKind.Utc);
        var range = new DateRange(day.AddHours(8), day.AddHours(10));

        Assert.Throws<ArgumentNullException>(() => DateRange.Overlaps(range, null!));
        Assert.Throws<ArgumentNullException>(() => DateRange.Overlaps(null!, range));
    }
}
