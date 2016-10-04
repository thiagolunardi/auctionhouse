using Auctionata.Domain.Entities.Common;
using Auctionata.Domain.Entities.Validations;
using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Entities
{
    /// <summary>
    /// Rules list to guide the auction product item price Incremental
    /// </summary>
    public class IncrementalRule : Identity, ISelfValidation
    {
        /// <summary>
        /// Minimum value to apply the increment
        /// </summary>
        public decimal MinimumItemValue { get; set; }
        /// <summary>
        /// Amount that should be incremented after the first bid
        /// </summary>
        public decimal Increment { get; set; }

        public override bool IsValid
        {
            get
            {
                var fiscal = new IncrementalRangeIsValidValidation();
                var result = fiscal.Valid(this);

                ValidationErrors = result.Errors;
                return result.IsValid;
            }
        }
    }
}