using Microsoft.JSInterop;


namespace Client.Services.Sessions;

public class SessionStorage(IJSRuntime jSRuntime) : ISessionStorage
{
    private readonly IJSRuntime _jSRuntime = jSRuntime;
    
    public async Task<T> GetItem<T>(string key) => await _jSRuntime.InvokeAsync<T>("storage.session.getItem", key);

    public async void RemoveItem(string key) => await _jSRuntime.InvokeVoidAsync("storage.session.removeItem", key);

    public async void SetItem<T>(string key, T item) => await _jSRuntime.InvokeVoidAsync("storage.session.setItem", key, item);
}
