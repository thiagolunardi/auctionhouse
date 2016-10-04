using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Entities.Validations.Specifications.ItemSpecs
{
    public class ItemStartingBidShouldBeGraterThanZeroSpec : ISpecification<Item>
    {
        public string ErrorMessage { get; private set; }

        public bool IsSatisfiedBy(Item item)
        {
            var isSatisfiedBy = item.StartingBid > 0m;

            if (!isSatisfiedBy)
                ErrorMessage = string.Format(SpecificationMessages.DataShoudBeGreaterThan, SpecificationMessages.StartingBid, 0m.ToString("C"));

            return isSatisfiedBy;
        }
    }
}