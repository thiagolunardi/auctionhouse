using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Entities.Validations.Specifications.IncrementalRangeSpecs
{
    public class IncrementalRangeMinimumItemValueShouldBeGraterThanZeroSpec : ISpecification<IncrementalRule>
    {
        public string ErrorMessage { get; private set; }

        public bool IsSatisfiedBy(IncrementalRule incrementalRule)
        {
            var isSatisfiedBy = incrementalRule.MinimumItemValue > 0m;

            if (!isSatisfiedBy)
                ErrorMessage = string.Format(SpecificationMessages.DataShoudBeGreaterThan, SpecificationMessages.MinimumItemValue, 0m.ToString("C"));

            return isSatisfiedBy;
        }
    }
}