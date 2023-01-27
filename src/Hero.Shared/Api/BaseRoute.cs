using Microsoft.AspNetCore.Mvc;

namespace Shared.Api
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class BaseRouteAttribute : RouteAttribute
    {
        public BaseRouteAttribute(string controller)
           : base($"api/{controller}")
        {
        }
    }
}
