using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Entities.Validations.Specifications.ItemSpecs
{
    public class ItemEstimateShouldBeGreaterThanZeroSpec : ISpecification<Item>
    {
        public string ErrorMessage { get; private set; }

        public bool IsSatisfiedBy(Item item)
        {
            var isSatisfiedBy = item.Estimate > 0m;

            if (!isSatisfiedBy)
                ErrorMessage = string.Format(SpecificationMessages.DataShoudBeGreaterThan, SpecificationMessages.Estimate, 0m.ToString("C"));

            return isSatisfiedBy;
        }
    }
}