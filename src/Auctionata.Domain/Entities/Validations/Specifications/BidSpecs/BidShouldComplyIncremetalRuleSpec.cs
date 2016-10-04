using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Entities.Validations.Specifications.BidSpecs
{
    public class BidShouldComplyIncremetalRuleSpec: ISpecification<Bid>
    {
        public string ErrorMessage { get; private set; }

        public bool IsSatisfiedBy(Bid bid)
        {
            var maxBidValue = bid.Room.NextPrice();
            var isSatisfiedBy = bid.Amount <= maxBidValue;

            if (!isSatisfiedBy)
                ErrorMessage = SpecificationMessages.AuctionBidRuleViolated;

            return isSatisfiedBy;
        }
    }
}