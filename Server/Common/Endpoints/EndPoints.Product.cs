namespace Server.Common.Endpoints;

public static partial class EndPoints
{
    public static class Products
    {
        public const string Controller = "products";

        public static class Get
        { 
            public const string All = "page/{page}/page-size/{pageSize}";
            public const string ById = "{productId}";
            public const string ByCategory = "category/{categoryId}/page/{page}/page-size/{pageSize}";
        }
    }
}
