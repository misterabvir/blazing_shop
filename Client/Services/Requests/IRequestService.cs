using Shared.Results;

namespace Client.Services.Requests;

public interface IRequestService
{
    
    Task<Result<T>> GetAsync<T>(string url, string token = "");
    Task<Result<IEnumerable<T>>> GetIEnumerableAsync<T>(string url, string token = "");
    Task<Result> PostAsync(string url, object data, string token = "");
    Task<Result<T>> PostAsync<T>(string url, object data, string token = "");
    Task<Result<T>> PutAsync<T>(string url, object data, string token = "");
    Task<Result<T>> DeleteAsync<T>(string url, object data, string token = "");
}
