using System.Dynamic;

public partial class SessionParticipant
{
    public Musician Participant { get; }
    public InstrumentType Instrument { get; }
    public SessionRole Role { get; }

    internal SessionParticipant(Musician participant, InstrumentType instrument, SessionRole role)
    {
        if (participant is null)
        {
            throw new ArgumentException("O participante deve ter uma referência a um Músico válido.");
        }

        this.Participant = participant;
        this.Instrument = instrument;
        this.Role = role;
    }
    
}