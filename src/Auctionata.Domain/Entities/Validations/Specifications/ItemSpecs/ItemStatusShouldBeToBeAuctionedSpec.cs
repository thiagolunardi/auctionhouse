using Auctionata.Domain.Entities.Types;
using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Entities.Validations.Specifications.ItemSpecs
{
    public class ItemStatusShouldBeToBeAuctionedSpec : ISpecification<Item>
    {
        public string ErrorMessage { get; private set; }

        public bool IsSatisfiedBy(Item item)
        {
            var isSatisfiedBy = item.Status == ItemStatus.ToBeAuctioned;

            if (!isSatisfiedBy)
                ErrorMessage = SpecificationMessages.TheItemIsInAuctionOrSold;

            return isSatisfiedBy;
        }
    }
}