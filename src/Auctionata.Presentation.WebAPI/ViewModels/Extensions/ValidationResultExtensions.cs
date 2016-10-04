using System.Web.Http.ModelBinding;
using Auctionata.Application.Validation;

namespace Auctionata.Presentation.WebAPI.ViewModels.Extensions
{
    public static class ValidationResultExtensions
    {
        public static ModelStateDictionary ToModelState(this ValidationResult result)
        {
            var modelState = new ModelStateDictionary();
            foreach (var error in result.Errors)
            {
                modelState.AddModelError("", error.Message);
            }
            return modelState;
        }
    }
}