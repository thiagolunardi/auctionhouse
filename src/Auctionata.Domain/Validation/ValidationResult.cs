using System.Collections.Generic;
using System.Linq;

namespace Auctionata.Domain.Validation
{
    public class ValidationResult 
    {
        private readonly List<ValidationError> _erros;
        public bool IsValid => !_erros.Any();
        public IEnumerable<ValidationError> Errors => _erros;
        public object Entity { get; set; }

        public ValidationResult()
        {
            _erros = new List<ValidationError>();
        }

        public ValidationResult Add(string errorMessage)
        {
            _erros.Add(new ValidationError(errorMessage));
            return this;
        }

        public ValidationResult Add(ValidationError error)
        {
            _erros.Add(error);
            return this;
        }

        public ValidationResult Add(params ValidationResult[] validationResults)
        {
            if (validationResults == null) return this;

            foreach (var result in validationResults.Where(r => r != null))
                _erros.AddRange(result.Errors);

            if (Entity == null)
            {
                Entity = validationResults
                    .Where(vr => vr.Entity != null)
                    .Select(vr => vr.Entity)
                    .FirstOrDefault();
            }

            return this;
        }
    }
}
