using Auctionata.Domain.Entities.Validations.Specifications.RoomSpecs;
using Auctionata.Domain.Specification;

namespace Auctionata.Domain.Entities.Validations
{
    public sealed class RoomCanReceiveAttendantValidation : Inspector<Room>
    {
        public RoomCanReceiveAttendantValidation()
        {
            AddSpecification(new RoomStatusShouldBeInAuctionSpec());
        }
    }
}