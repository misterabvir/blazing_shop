using Client.Services.ToastMessages;
using Newtonsoft.Json;
using Shared.Results;
using System.Net.Http.Json;

namespace Client.Services.Requests;

public class RequestService(HttpClient httpClient, IToastMessageService toastMessageService) : IRequestService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly IToastMessageService _toastMessageService = toastMessageService;

    public async Task<Result<T>> GetAsync<T>(string url, string token = "")
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Authorization", $"Bearer {token}");
        var response = await _httpClient.SendAsync(request);
        return await GetResult<T>(response);
    }

    public async Task<Result<T>> GetIEnumerableAsync<T>(string url, string token = "")
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Authorization", $"Bearer {token}");
        var response = await _httpClient.SendAsync(request);
        return await GetResult<T>(response);
    }

    public async Task<Result> PostAsync(string url, object data, string token = "")
    {
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(data);
        var response = await _httpClient.SendAsync(request);
        return await GetResult(response);
    }

    public async Task<Result<T>> PostAsync<T>(string url, object data, string token = "")
    {
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(data);
        var response = await _httpClient.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        return await GetResult<T>(response);
    }

    public async Task<Result<T>> PutAsync<T>(string url, object data, string token = "")
    {
        var request = new HttpRequestMessage(HttpMethod.Put, url);
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(data);
        var response = await _httpClient.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        return await GetResult<T>(response);
    }

    public async Task<Result<T>> DeleteAsync<T>(string url, object data, string token = "")
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, url);
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(data);
        var response = await _httpClient.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        return await GetResult<T>(response);
    }

    public async Task<Result> PutAsync(string url, object data, string token = "")
    {
        var request = new HttpRequestMessage(HttpMethod.Put, url);
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(data);
        var response = await _httpClient.SendAsync(request);       
        return await GetResult(response);
    }

    
    private async Task<Result<T>> GetResult<T>(HttpResponseMessage response)
    {
        var json = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            var value = JsonConvert.DeserializeObject<T>(json);
            if (value is null)
            {
                return Error.InternalServerError("Something went wrong");
            }
            return value;
        }
        var errors = JsonConvert.DeserializeObject<List<Error>>(json);
        if (errors is not null)
        {
            _toastMessageService.AddErrorMessage(errors);
            return errors;
        }

        return Error.InternalServerError("Something went wrong");
    }


    private async Task<Result> GetResult(HttpResponseMessage response)
    {
        var json = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            return Result.Success();
        }
        var errors = JsonConvert.DeserializeObject<List<Error>>(json);
        if (errors is not null)
        {
            _toastMessageService.AddErrorMessage(errors);
            return errors;
        }

        return Error.InternalServerError("Something went wrong");
    }
}
