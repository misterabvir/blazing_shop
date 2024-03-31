using Microsoft.AspNetCore.Mvc;
using Shared.Results;

namespace Server.Common.Extensions;

public static class SharedExtensions
{
    public static IActionResult Match<T>(
        this Result<T> result,
        Func<object, IActionResult> success,
        Func<object, IActionResult> failure)
        => result.IsSuccess ? success(result.Value!) : failure(result.Errors);
}
