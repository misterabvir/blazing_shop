using Application.Users.Commands.Register;
using Application.Users.Queries.Login;
using Application.Users.Responses;
using Contracts.Authentications;
using Domain.Users;
using Shared.Results;

namespace Server.Common.Extensions;

public static class UserExtensions
{
    public static Result<TokenResponse> Map(this Result<TokenResult> result)
     => result.IsSuccess ? new TokenResponse(result.Value!.Token) : result.Errors; 

    public static Result<AccountResponse> Map(this Result<User> result)
        => result.IsSuccess ? 
        new AccountResponse(
            result.Value!.Id.Value, 
            result.Value!.Role.Value,
            result.Value!.Contact.Email.Value, 
            result.Value!.Contact.Phone.Value, 
            result.Value!.Profile.Username.Value, 
            result.Value!.Profile.FirstName.Value, 
            result.Value!.Profile.LastName.Value,
            result.Value!.Profile.Avatar?.Value
            ) : 
        result.Errors;

    public static RegisterCommand Map(this RegisterRequest request)
        => new (request.Username,
                request.Email,
                request.Phone,
                request.FirstName,
                request.LastName,
                request.Password);

    public static LoginQuery Map(this LoginRequest request)
        => new (request.Email, request.Password);
}
