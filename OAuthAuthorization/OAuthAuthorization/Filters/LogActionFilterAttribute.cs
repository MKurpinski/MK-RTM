using System.Diagnostics;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace OAuthAuthorization.Filters
{
    public class LogActionFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var isAuthenticated = actionContext.RequestContext.Principal.Identity.IsAuthenticated;

            var message = $"User(authenticated: {isAuthenticated}) invokes http method: {actionContext.Request.Method} " +
                          $"on controller: {actionContext.ControllerContext.ControllerDescriptor.ControllerName}";

            Debug.WriteLine(message);
            base.OnActionExecuting(actionContext);
        }
    }
}