namespace Shared.Pagination;

public class Pagination<T>
{
    public int Page { get; init; }
    public int PageSize { get; init; }
    public int Count { get; init; }
    public List<T> Items { get; init; } = [];
}