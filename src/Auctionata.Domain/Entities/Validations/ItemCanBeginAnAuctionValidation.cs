using Auctionata.Domain.Entities.Validations.Specifications.ItemSpecs;
using Auctionata.Domain.Specification;

namespace Auctionata.Domain.Entities.Validations
{
    public sealed class ItemCanBeginAnAuctionValidation : Inspector<Item>
    {
        public ItemCanBeginAnAuctionValidation()
        {
            AddSpecification(new ItemStatusShouldBeToBeAuctionedSpec());
        }
    }
}