using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace test_previsul.Domain.Bases
{
    public class CustomControllerBase : Controller
    {
        public static List<ErroValidation> ValidateModelState(ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
                return new List<ErroValidation>();

            return modelState.Where(x => x.Value.Errors.Any())
                .ToDictionary(kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).First())
                .Select(x => new ErroValidation { Property = x.Key, Message = x.Value })
                .ToList();
        }

        public JsonResult JsonModelErrors(List<ErroValidation> errors) =>
          Json(new { success = false, errors });

        public JsonResult JsonSuccess(string message) =>
           Json(new { success = true, message });

        public JsonResult JsonSuccess(string message, string redirectUrl) =>
           Json(new { success = true, message, redirectUrl });

        public JsonResult JsonError(string message) =>
           Json(new { success = false, message });

        public class ErroValidation
        {
            public string Property { get; set; }
            public string Message { get; set; }
        }
    }
}
