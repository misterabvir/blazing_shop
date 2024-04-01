
namespace Server.Common.Endpoints;

public static partial class EndPoints
{
    public static class User
    {
        public const string Controller = "authentication";

        public static class Post
        {
            public const string Register = "register";
            public const string Login = "login";
            public const string Verify = "verify";
            public const string RepeatVerification = "repeat-verification";
        }

        public static class Get
        {
            public const string RefreshToken = "refresh-token";
            public const string Account = "account";
        }
    }
}


