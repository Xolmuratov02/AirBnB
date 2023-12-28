using AirBnB.Application.RequestContexts.Brokers;
using AirBnB.Application.RequestContexts.Constants;
using AirBnB.Application.RequestContexts.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace AirBnB.Infrastructure.RequestContexts.Brokers;

public class RequestContextProvider(IHttpContextAccessor httpContextAccessor) : IRequestContextProvider
{
    public RequestContext GetRequestContext()
    {
        var httpContext = httpContextAccessor.HttpContext!;
        var userInfoCookie = httpContext.Request.Cookies.TryGetValue(CookieConstants.UserInfoCookieKey, out var userInfoCookieValue)
            ? JsonConvert.DeserializeObject<UserInfo>(userInfoCookieValue!)
            : default;

        var requestContext = new RequestContext
        {
            UserInfo = userInfoCookie
        };

        return requestContext;
    }
}