namespace Client.Services.Icons;

public record Icon(string Name, string Value)
{
    public static Icon Empty => new("none", string.Empty);
}