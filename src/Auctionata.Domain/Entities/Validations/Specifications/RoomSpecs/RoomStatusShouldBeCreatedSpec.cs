using Auctionata.Domain.Entities.Types;
using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Entities.Validations.Specifications.RoomSpecs
{
    public class RoomStatusShouldBeCreatedSpec : ISpecification<Room>
    {
        public string ErrorMessage { get; private set; }

        public bool IsSatisfiedBy(Room room)
        {
            var isSatisfiedBy = room.Status == RoomStatus.Created;

            if (!isSatisfiedBy)
                ErrorMessage = SpecificationMessages.TheRoomIsInAuctionOrEnded;

            return isSatisfiedBy;
        }
    }
}