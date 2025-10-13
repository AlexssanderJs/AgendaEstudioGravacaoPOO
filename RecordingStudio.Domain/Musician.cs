namespace RecordingStudio.Domain;

public class Musician
{
    public int Id { get; }
    public string FullName { get; }
    public string? StageName { get; }

    public UnionCard? UnionCard { get; private set; }

    public Musician(int id, string fullName, string? stageName)
    {
        if (id <= 0)
        {
            throw new ArgumentException("O ID tem que ser maior que 0");
        }

        if (string.IsNullOrWhiteSpace(fullName.Trim()))
        {
            throw new ArgumentException("O musico deve ter um nome");
        }

        if (string.IsNullOrWhiteSpace(stageName))
        {
            stageName = fullName;
        }

        this.Id = id;
        this.FullName = fullName;
        this.StageName = stageName;
    }

    public void AssignUnionCard(string number, DateTime expiration)
    {
        if (UnionCard is not null)
        {
            throw new InvalidOperationException("Este músico já possui uma UnionCard.");
        }

        var newCard = new UnionCard(number, expiration);

        this.UnionCard = newCard;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Musician other)
        {
            return false;
        }

        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

}
