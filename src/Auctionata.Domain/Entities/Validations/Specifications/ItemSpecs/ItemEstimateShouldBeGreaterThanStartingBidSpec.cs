using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Entities.Validations.Specifications.ItemSpecs
{
    public class ItemEstimateShouldBeGreaterThanStartingBidSpec : ISpecification<Item>
    {
        public string ErrorMessage { get; private set; }

        public bool IsSatisfiedBy(Item item)
        {
            var isSatisfiedBy = item.Estimate > item.StartingBid;

            if (!isSatisfiedBy)
                ErrorMessage = string.Format(SpecificationMessages.DataShoudBeGreaterThan, SpecificationMessages.Estimate, SpecificationMessages.StartingBid);

            return isSatisfiedBy;
        }
    }
}