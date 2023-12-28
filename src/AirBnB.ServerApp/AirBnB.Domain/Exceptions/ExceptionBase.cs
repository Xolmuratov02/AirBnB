using AirBnB.Domain.Common.Exceptions;

namespace AirBnB.Domain.Exceptions;

public abstract class ExceptionBase(
    string? message = default,
    Exception? innerException = default,
    ExceptionVisibility visibility = ExceptionVisibility.Public
) : Exception(message, innerException)
{
    public ExceptionVisibility Visibility { get; set; } = visibility;
}