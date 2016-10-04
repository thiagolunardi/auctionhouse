using Auctionata.Domain.Entities.Validations.Specifications.RoomSpecs;
using Auctionata.Domain.Specification;

namespace Auctionata.Domain.Entities.Validations
{
    public sealed class RoomCanAddItemValidation : Inspector<Room>
    {
        public RoomCanAddItemValidation()
        {
            AddSpecification(new RoomStatusShouldBeCreatedSpec());
        }
    }
}