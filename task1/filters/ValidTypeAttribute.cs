using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;
using task1.models;

namespace task1.filters
{
    public class ValidTypeAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var car= context.ActionArguments["newCar"] as Car;
            var regex = new Regex("^(Electric|Gas|Diesel|Hybrid)$", RegexOptions.IgnoreCase, TimeSpan.FromSeconds(2));
            if(car==null||!regex.IsMatch(car.type))
            {
                context.ModelState.AddModelError("type", "type isn't match");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
                
        }
    }
}
