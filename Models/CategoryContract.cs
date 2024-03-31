namespace Models;

public class CategoryContract
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public List<ProductContract> Products { get; set; } = [];
}