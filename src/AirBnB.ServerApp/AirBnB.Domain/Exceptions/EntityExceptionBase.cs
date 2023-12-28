using AirBnB.Domain.Common.Exceptions;

namespace AirBnB.Domain.Exceptions;

public class EntityExceptionBase(
    Guid entityId,
    string? message = default,
    Exception? innerException = default,
    ExceptionVisibility visibility = ExceptionVisibility.Public
) : ExceptionBase(message, innerException, visibility)
{
    public Guid Id { get; set; } = entityId;
}