namespace Client.Services.Icons;

public interface IIconService
{
    Task<List<Icon>> GetIcons();
}
