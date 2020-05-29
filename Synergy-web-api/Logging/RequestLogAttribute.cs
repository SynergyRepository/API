
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Synergy_web_api.Logging
{
    public class RequestLogAttribute : ActionFilterAttribute
    {
        private string modelArgument;
        private static Logger log = LogManager.GetCurrentClassLogger();
        public RequestLogAttribute(string parameterName)
        {
            modelArgument = parameterName;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string payload = "";
            try
            {
                string httpMethod = actionContext.Request.Method.Method;
                string url = actionContext.Request.RequestUri.AbsoluteUri;

                if(actionContext.ActionArguments.Count > 0)
                {
                    var arguement = actionContext.ActionArguments[modelArgument];
                    if (arguement != null)
                        payload = JsonConvert.SerializeObject(arguement);
                }
            }
            catch (Exception ex)
            {

                log.Error(ex.Message, "RequestLogAttribute OnActionExecuting");
            }
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            string payload = "";
            try
            {
                if (actionExecutedContext.Exception != null)
                    payload = actionExecutedContext.Exception.ToString();
                else
                    payload = actionExecutedContext.Response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception)
            {

                throw;
            }

            base.OnActionExecuted(actionExecutedContext);
        }

    }
}
