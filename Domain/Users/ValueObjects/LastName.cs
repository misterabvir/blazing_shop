﻿namespace Domain.Users.ValueObjects;

public record LastName
{
    public string Value { get; init; }
    private LastName(string value) => Value = value;
    public static LastName Create(string value) => new(value);
}
