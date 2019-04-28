using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Core.Controllers
{
    public class BaseController : Controller
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Session.GetString("UserLog") == null)
                filterContext.Result = this.RedirectToAction("Login", "LogUser", new { area = "" });

            base.OnActionExecuting(filterContext);
        }
    }
}