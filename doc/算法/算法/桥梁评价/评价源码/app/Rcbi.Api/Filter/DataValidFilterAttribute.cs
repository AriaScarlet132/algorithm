using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Rcbi.Entity.OpenApi;

namespace Rcbi.Api.Filter
{
    public class DataValidFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var result = new OpenApiResult<string>();

                foreach (var item in context.ModelState.Values)
                {
                    var success = true;

                    foreach (var error in item.Errors)
                    {
                        result.Status = 400;
                        result.Message = error.ErrorMessage;
                        success = false;
                        break;
                    }

                    if (!success) break;
                }
                context.Result = new JsonResult(result);

                return;
            }

            base.OnResultExecuting(context);
        }
    }
}
