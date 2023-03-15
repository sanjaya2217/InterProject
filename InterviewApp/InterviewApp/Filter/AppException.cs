using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLog;


namespace InterviewApp.Filter
{
    public class AppException : ActionFilterAttribute,IExceptionFilter
    {
        Logger _logger = LogManager.GetCurrentClassLogger();
        public void OnException(ExceptionContext filterContext)
        {
            _logger.Error(filterContext.Exception.ToString());

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
            };

            filterContext.ExceptionHandled = true;
        }
    }
}