using Auctionata.Domain.Entities.Validations.Specifications.BuyerSpecs;
using Auctionata.Domain.Specification;

namespace Auctionata.Domain.Entities.Validations
{
    public sealed class BuyerIsValidValidation : Inspector<Buyer>
    {
        public BuyerIsValidValidation()
        {
            AddSpecification(new BuyerShouldHaveNameSpec());
            AddSpecification(new BuyerShouldHaveCountrySpec());
        }
    }
}