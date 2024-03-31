namespace Server.Common.Endpoints;

public static partial class EndPoints
{
    public static class Category
    {
        public const string Controller = "categories";

        public static class Get
        {
            public const string All = "";
            public const string ByUrl = "by-url/{url}";
        }
        public static class Post
        {
            public const string Create = "create";
        }
    }
}
