using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomFiltersInCore.Filters
{
    public class ResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("OnResultExecuting", "Header Added by Result Filter");
        }
    }
    public class AddHeaderAttribute:TypeFilterAttribute
    {
        public AddHeaderAttribute():base(typeof(AddHeaderAttribute))
        {

        }
    }
}
