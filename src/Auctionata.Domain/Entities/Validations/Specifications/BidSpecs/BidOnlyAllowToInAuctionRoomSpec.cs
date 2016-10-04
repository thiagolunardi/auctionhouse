using Auctionata.Domain.Entities.Types;
using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Entities.Validations.Specifications.BidSpecs
{
    public class BidOnlyAllowToInAuctionRoomSpec: ISpecification<Bid>
    {
        public string ErrorMessage { get; private set; }

        public bool IsSatisfiedBy(Bid bid)
        {
            var isSatisfiedBy = bid.Room.Status == RoomStatus.InAuction;

            if (!isSatisfiedBy)
                ErrorMessage = SpecificationMessages.ThisRoomIsNotInAuction;

            return isSatisfiedBy;
        }
    }
}