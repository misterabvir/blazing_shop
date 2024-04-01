using Shared.Results;

namespace Domain.Users.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error UsernameAlreadyTaken => Error.Conflict("User.Register", "Username already taken");
        public static Error EmailAlreadyTaken => Error.Conflict("User.Register", "Email already taken");
        public static Error PhoneNumberAlreadyTaken => Error.Conflict("User.Register", "Phone number already taken");
        public static Error InvalidCredentials => Error.Conflict("User.Login", "Invalid credentials");
        public static Error NotFound => Error.Conflict("User.NotFound", "User not found"); 
    }
}
