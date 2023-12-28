using AirBnB.Application.RequestContexts.Models;

namespace AirBnB.Application.RequestContexts.Brokers;

public interface IRequestContextProvider
{
    RequestContext GetRequestContext();
}