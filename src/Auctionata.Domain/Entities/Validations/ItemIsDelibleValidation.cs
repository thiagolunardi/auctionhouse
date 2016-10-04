using Auctionata.Domain.Entities.Validations.Specifications.ItemSpecs;
using Auctionata.Domain.Specification;

namespace Auctionata.Domain.Entities.Validations
{
    public sealed class ItemIsDelibleValidation : Inspector<Item>
    {
        public ItemIsDelibleValidation()
        {
            AddSpecification(new ItemStatusShouldBeToBeAuctionedSpec());
        }
    }
}