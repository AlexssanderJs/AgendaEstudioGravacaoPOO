public class Musician
{
    public int Id { get; private set; }
    public string FullName { get; private set; }
    public string? StageName { get; private set; }

    public Musician (int id, string fullName, string? stageName)
    {
        if (id <= 0)
        {
            throw new ArgumentException("O ID tem que ser maior que 0");
        }

        if (string.IsNullOrWhiteSpace(fullName))
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

}
