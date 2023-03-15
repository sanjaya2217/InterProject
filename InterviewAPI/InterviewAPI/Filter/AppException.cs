using Microsoft.AspNetCore.Mvc.Filters;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using InterviewAPI.Models;

namespace InterviewAPI.Filter
{
    //Filter to log exception
    public class AppException : ActionFilterAttribute, IExceptionFilter
    {
        Logger _logger = LogManager.GetCurrentClassLogger();
        public void OnException(ExceptionContext context)
        {
            _logger.Error("Error Details : " + context.Exception.ToString());
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = Convert.ToInt32(AppConst.BadStatusCode);
            
            //Send Response
            context.Result = new ObjectResult(new APIResult()
            {   message = context.Exception.Message,
                statuscode = AppConst.BadStatusCode,
                timestamp = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            });

        }
    }
}