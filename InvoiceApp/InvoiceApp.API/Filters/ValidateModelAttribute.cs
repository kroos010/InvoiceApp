using InvoiceApp.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace InvoiceApp.API;

public class ValidateModelAttribute : Attribute, IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            // var errors = context.ModelState.Values
            //     .SelectMany(modelState => modelState.Errors)
            //     .Select(modelError => modelError.ErrorMessage);

            var errorDictionary = new Dictionary<string, List<string>>();

            foreach (var modelStateErrorKeys in context.ModelState.Keys)
            {
                foreach (var item in context.ModelState[modelStateErrorKeys]?.Errors!)
                {
                    if (!errorDictionary.ContainsKey(modelStateErrorKeys))
                    {
                        //First result so we must add the key first
                        errorDictionary.Add(modelStateErrorKeys, new List<string>
                        {
                            item.ErrorMessage
                        });
                    }
                    else
                    {
                        errorDictionary[modelStateErrorKeys].Add(item.ErrorMessage);
                    }
                }
            }

            context.Result = new BadRequestObjectResult(ApiResult<string>.Failure(errorDictionary));
        }

        await next();
    }
}