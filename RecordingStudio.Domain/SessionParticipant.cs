namespace RecordingStudio.Domain;

public partial class SessionParticipant
{
    public Musician Participant { get; }
    public InstrumentType Instrument { get; }
    public SessionRole Role { get; }
    public DateTime? ArrivalTime { get; }

    internal SessionParticipant(Musician participant, InstrumentType instrument, SessionRole role, DateTime? arrivalTime)
    {
        if (participant is null)
        {
            throw new ArgumentNullException(nameof(participant));
        }

        Participant = participant;
        Instrument = instrument;
        Role = role;
        ArrivalTime = arrivalTime;
    }

}