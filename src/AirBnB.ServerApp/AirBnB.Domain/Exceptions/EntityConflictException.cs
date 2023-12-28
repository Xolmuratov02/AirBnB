using AirBnB.Domain.Common.Entities;
using AirBnB.Domain.Common.Exceptions;

namespace AirBnB.Domain.Exceptions;

public class EntityConflictException<TEntity>(
    Guid entityId,
    Exception innerException,
    ExceptionVisibility exceptionVisibility = ExceptionVisibility.Protected
) : EntityExceptionBase(
    entityId,
    $"Entity {typeof(TEntity).Name} with id {entityId} has conflicts to execute this operation",
    innerException,
    exceptionVisibility
) where TEntity : IEntity;