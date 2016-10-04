using Auctionata.Domain.Entities.Validations.Specifications.ItemSpecs;
using Auctionata.Domain.Specification;

namespace Auctionata.Domain.Entities.Validations
{
    public sealed class ItemIsValidValidation : Inspector<Item>
    {
        public ItemIsValidValidation()
        {
            AddSpecification(new ItemEstimateShouldBeGreaterThanStartingBidSpec());
            AddSpecification(new ItemEstimateShouldBeGreaterThanZeroSpec());
            AddSpecification(new ItemShouldHaveDescriptionSpec());
            AddSpecification(new ItemShouldHaveDetailedInformationSpec());
            AddSpecification(new ItemShouldHaveNameSpec());
            AddSpecification(new ItemShouldHavePictureSpec());
            AddSpecification(new ItemStartingBidShouldBeGraterThanZeroSpec());
        }
    }
}