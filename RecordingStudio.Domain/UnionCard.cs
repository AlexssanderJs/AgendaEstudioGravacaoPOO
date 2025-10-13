namespace RecordingStudio.Domain;

public class UnionCard
{
    public string Number { get; }
    public DateTime Expiration { get; }

    public UnionCard(string number, DateTime expiration)
    {
        if (string.IsNullOrWhiteSpace(number))
        {
            throw new ArgumentException("O numero não pode ser nulo nem vazio");
        }

        if (expiration <= DateTime.Now)
        {
            throw new ArgumentException("A data de expiração deve ser futura");
        }

        this.Number = number;
        this.Expiration = expiration;
    }

}