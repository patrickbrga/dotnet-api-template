using Microsoft.AspNetCore.Mvc;

namespace Shared.Api
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class BaseRoute : RouteAttribute
    {
        public BaseRoute(string controller)
           : base($"api/{controller}")
        {
        }
    }
}
