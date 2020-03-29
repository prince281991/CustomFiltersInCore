﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomFiltersInCore.Filters
{
    public class ValidateModelFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.ActionArguments.SingleOrDefault();
            if(param.Value==null)
            {
                context.Result = new BadRequestObjectResult("Model is null");
                return;
            }
            if(context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            
        }
    }
}
