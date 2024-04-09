namespace Contracts.Categories;

public class CategoryContract
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public List<PublishVariantContract> PublishVariants { get; set; } = [];
}
