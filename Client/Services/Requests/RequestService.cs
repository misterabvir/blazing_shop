using Newtonsoft.Json;
using Shared.Results;
using System.Net.Http.Json;

namespace Client.Services.Requests;

public class RequestService(HttpClient httpClient) : IRequestService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<Result<T>> GetAsync<T>(string url, string token = "")
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Authorization", $"Bearer {token}");
        var response = await _httpClient.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            var data = JsonConvert.DeserializeObject<T>(json)!;
            return data;
        }
        var errors = JsonConvert.DeserializeObject<List<Error>>(json)!;
        return errors;
    }

    public async Task<Result<IEnumerable<T>>> GetIEnumerableAsync<T>(string url, string token = "")
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Authorization", $"Bearer {token}");
        var response = await _httpClient.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            var data = JsonConvert.DeserializeObject<IEnumerable<T>>(json)!;
            return data.ToList();
        }
        var errors = JsonConvert.DeserializeObject<List<Error>>(json)!;
        return errors;
    }

    public async Task<Result> PostAsync(string url, object data, string token = "")
    {
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(data);
        var response = await _httpClient.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            return Result.Success();
        }
        var errors = JsonConvert.DeserializeObject<List<Error>>(json)!;
        return errors;
    }

    public async Task<Result<T>> PostAsync<T>(string url, object data, string token = "")
    {
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(data);
        var response = await _httpClient.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<T>(json)!;
        }
        var errors = JsonConvert.DeserializeObject<List<Error>>(json)!;
        return errors;
    }

    public async Task<Result<T>> PutAsync<T>(string url, object data, string token = "")
    {
        var request = new HttpRequestMessage(HttpMethod.Put, url);
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(data);
        var response = await _httpClient.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<T>(json)!;
        }
        var errors = JsonConvert.DeserializeObject<List<Error>>(json)!;
        return errors;
    }

    public async Task<Result<T>> DeleteAsync<T>(string url, object data, string token = "")
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, url);
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(data);
        var response = await _httpClient.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<T>(json)!;
        }
        var errors = JsonConvert.DeserializeObject<List<Error>>(json)!;
        return errors;
    }

    public async Task<Result> PutAsync(string url, object data, string token = "")
    {
        var request = new HttpRequestMessage(HttpMethod.Put, url);
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(data);
        var response = await _httpClient.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            return Result.Success();
        }
        var errors = JsonConvert.DeserializeObject<List<Error>>(json)!;
        return errors;
    }
}
