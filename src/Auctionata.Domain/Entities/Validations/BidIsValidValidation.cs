using Auctionata.Domain.Entities.Validations.Specifications.BidSpecs;
using Auctionata.Domain.Specification;

namespace Auctionata.Domain.Entities.Validations
{
    public sealed class BidIsValidValidation : Inspector<Bid>
    {
        public BidIsValidValidation()
        {
            AddSpecification(new BidShouldComplyIncremetalRuleSpec());
        }
    }
}