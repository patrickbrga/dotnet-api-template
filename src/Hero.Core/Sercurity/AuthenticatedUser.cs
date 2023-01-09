using Core.Interfaces.Security;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Core.Sercurity
{
    public class AuthenticatedUser : IAuthenticatedUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AuthenticatedUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Email()
        {
            return _accessor.HttpContext.User.Identity.Name;
        }

        public string Name()
        {
            return GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.Name)?.Value;
        }

        public string RemoteIp()
        {
            return _accessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

        public Guid GuidLogin()
        {
            try
            {
                var guidLogin = GetClaimsIdentity().FirstOrDefault(a => a.Type == "id")?.Value;

                return string.IsNullOrEmpty(guidLogin) ? Guid.Empty : Guid.Parse(guidLogin);
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }

        public string GetToken()
        {
            _accessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token);

            return token;
        }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor?.HttpContext?.User?.Claims;
        }

        public string GetPermissionClaims()
        {
            return _accessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == "permission")?.Value;
        }

        public string GetGroupsClaims()
        {
            return _accessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == "groups")?.Value;
        }

        public string GetTokenTypeClaims()
        {
            return _accessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == "type")?.Value;
        }

        public string GetUserAgent()
        {
            return _accessor.HttpContext.Request.Headers["User-Agent"];
        }
    }
}