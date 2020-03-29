using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CustomFiltersInCore.Filters
{
    public class AuthorizeActionFilter : IAuthorizationFilter
    {
        private readonly string _permission;
        public AuthorizeActionFilter(string permission)
        {
            _permission = permission;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string isAuthorized = CheckUserPermission(context.HttpContext.User, _permission);
            if (isAuthorized != "true")
            {
                context.Result = new UnauthorizedResult();
            }
        }
        private string CheckUserPermission(ClaimsPrincipal user, string permission)
        {
            return permission = "true";
        }
    }

    public class AuthorizeAttribute:TypeFilterAttribute
    {
        public AuthorizeAttribute(string permission):base(typeof(AuthorizeActionFilter))
        {
            Arguments = new Object[] { permission };
        }
    }
}
