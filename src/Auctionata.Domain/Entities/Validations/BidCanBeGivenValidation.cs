using Auctionata.Domain.Entities.Validations.Specifications.BidSpecs;
using Auctionata.Domain.Specification;

namespace Auctionata.Domain.Entities.Validations
{
    public sealed class BidCanBeGivenValidation : Inspector<Bid>
    {
        public BidCanBeGivenValidation()
        {
            AddSpecification(new BidOnlyAllowToInAuctionRoomSpec());
        }
    }
}