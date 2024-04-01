namespace Client.Services.Sessions;

public interface ISessionStorage
{
    Task<T> GetItem<T>(string key);
    void RemoveItem(string key);
    void SetItem<T>(string key, T item);
}
