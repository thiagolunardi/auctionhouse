using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Entities.Validations.Specifications.BidSpecs
{
    public class BidValueShoulBeEqualOrLowerCurrentBidThanSpec: ISpecification<Bid>
    {
        public string ErrorMessage { get; private set; }

        public bool IsSatisfiedBy(Bid bid)
        {
            var isSatisfiedBy = bid.Amount <= bid.Room.NextPrice();

            if (!isSatisfiedBy)
                ErrorMessage = SpecificationMessages.InvalidBidValue;

            return isSatisfiedBy;
        }
    }
}