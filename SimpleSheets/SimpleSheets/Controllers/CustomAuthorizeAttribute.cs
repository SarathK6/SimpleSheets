using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace SimpleSheets.Controllers
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public string Roles { get; set; }
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            bool userAdmin = context.HttpContext.User.IsInRole(Roles);
            if(userAdmin)
            {
                return;
            }
            else
            {
                context.Result = new ViewResult
                {
                    ViewName = "AccessDenied"
                };
                
            }
        }
    }
}