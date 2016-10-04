using System.Collections.Generic;

namespace Auctionata.Domain.Validation
{
    public static class ValidationExtensions
    {
        public static ValidationResult ToValidationResult(this IEnumerable<ValidationError> erros)
        {
            var validationResult = new ValidationResult();
            foreach (var error in erros) validationResult.Add(error);
            return validationResult;
        }
    }
}