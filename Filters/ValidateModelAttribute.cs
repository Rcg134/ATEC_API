using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ATEC_API.GeneralModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ATEC_API.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                                    .SelectMany(modelStateEntry => modelStateEntry.Value.Errors.Select(error => new
                                    {
                                        Key = modelStateEntry.Key,
                                        Message = error.ErrorMessage
                                    }))
                                    .GroupBy(x => x.Key, x => x.Message)
                                    .ToDictionary(g => g.Key, g => g.ToArray());

                var errorResponse = new ErrorResponse
                {
                    status = (int)HttpStatusCode.BadRequest,
                    error = errors
                };

                context.Result = new BadRequestObjectResult(errorResponse);

            }
        }

    }
}