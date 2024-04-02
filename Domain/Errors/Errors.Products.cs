using Shared.Results;

namespace Domain.Errors;

public static partial class Errors
{
    public static class Products
    {
        public static Error NotFound => Error.NotFound("Product not found");
    }
}
