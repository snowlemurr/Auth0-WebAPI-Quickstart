using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApi.Attributes
{
    public class ScopeAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string scope;

        public ScopeAuthorizeAttribute(string scope)
        {
            this.scope = scope;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            ClaimsPrincipal principal = actionContext.ControllerContext.RequestContext.Principal as ClaimsPrincipal;
            if (principal != null && principal.HasClaim(c => c.Type == "scope"))
            {
                var scopes = principal.Claims.FirstOrDefault(c => c.Type == "scope").Value.Split(' ');

                if (!scopes.Any(s => s == scope))
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
        }
    }
}