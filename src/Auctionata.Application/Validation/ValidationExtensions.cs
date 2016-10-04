using System.Collections.Generic;
using Auctionata.Application.AutoMapper;

namespace Auctionata.Application.Validation
{
    public static class ValidationExtensions
    {
        public static ValidationResult ToValidationResult(this IEnumerable<ValidationError> erros)
        {
            var validationResult = new ValidationResult();
            foreach (var error in erros) validationResult.Add(error);
            return validationResult;
        }

        public static ValidationResult ToViewModel(this Domain.Validation.ValidationResult validationResult)
        {
            return Mapper.Map<ValidationResult>(validationResult);
        }
    }
}