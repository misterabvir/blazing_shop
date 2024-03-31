namespace Client.Services.Icons;

public class IconService(HttpClient httpClient) : IIconService
{
    private readonly HttpClient _httpClient = httpClient;
    private static List<Icon> _icons = [];
    public async Task<List<Icon>> GetIcons()
    {
        if(_icons.Count == 0)
        {
            var request = new HttpRequestMessage(
                HttpMethod.Get, 
                "https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.css");
            var response = await _httpClient.SendAsync(request);
            var text = await response.Content.ReadAsStringAsync();
            _icons = Parse(text);
        }

        return _icons;
    }

    private static List<Icon> Parse(string text) => text.Split("\n")
        .Where(x => x.Contains(".bi-"))
        .Select(x =>
        {
            var parts = x.Split("::");
            var value = parts.First().Replace(".bi-", "");

            return new Icon(value.Replace("-", " "), $"bi bi-{value}");
        }).ToList();
}
