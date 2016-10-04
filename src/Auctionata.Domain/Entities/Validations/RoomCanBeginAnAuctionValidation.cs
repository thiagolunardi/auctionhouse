using Auctionata.Domain.Entities.Validations.Specifications.RoomSpecs;
using Auctionata.Domain.Specification;

namespace Auctionata.Domain.Entities.Validations
{
    public sealed class RoomCanBeginAnAuctionValidation : Inspector<Room>
    {
        public RoomCanBeginAnAuctionValidation()
        {
            AddSpecification(new RoomStatusShouldBeCreatedSpec());
            AddSpecification(new RoomShouldHaveOneOrMoreRangesSpec());
            AddSpecification(new RoomShouldHaveOneOrMoreItemsSpec());
        }
    }
}