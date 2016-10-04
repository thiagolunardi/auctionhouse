using Auctionata.Domain.Entities.Validations.Specifications.IncrementalRangeSpecs;
using Auctionata.Domain.Specification;

namespace Auctionata.Domain.Entities.Validations
{
    public sealed class IncrementalRangeIsValidValidation : Inspector<IncrementalRule>
    {
        public IncrementalRangeIsValidValidation()
        {
            AddSpecification(new IncrementalRangeIncrementShouldBeGraterThanZeroSpec());
            AddSpecification(new IncrementalRangeMinimumItemValueShouldBeGraterThanZeroSpec());
        }
    }
}