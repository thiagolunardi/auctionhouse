using Auctionata.Domain.Entities.Types;
using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Entities.Validations.Specifications.RoomSpecs
{
    public class RoomStatusShouldBeInAuctionSpec : ISpecification<Room>
    {
        public string ErrorMessage { get; private set; }

        public bool IsSatisfiedBy(Room room)
        {
            var isSatisfiedBy = room.Status == RoomStatus.InAuction;

            if (!isSatisfiedBy)
                ErrorMessage = SpecificationMessages.TheRoomIsNotInAuction;

            return isSatisfiedBy;
        }
    }
}