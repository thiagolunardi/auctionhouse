using Auctionata.Domain.Entities.Validations.Specifications.RoomSpecs;
using Auctionata.Domain.Specification;

namespace Auctionata.Domain.Entities.Validations
{
    public sealed class RoomCanPlaceBidValidation : Inspector<Room>
    {
        public RoomCanPlaceBidValidation()
        {
            AddSpecification(new RoomStatusShouldBeInAuctionSpec());
        }
    }
}