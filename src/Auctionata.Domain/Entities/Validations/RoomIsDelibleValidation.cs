using Auctionata.Domain.Entities.Validations.Specifications.RoomSpecs;
using Auctionata.Domain.Specification;

namespace Auctionata.Domain.Entities.Validations
{
    public sealed class RoomIsDelibleValidation : Inspector<Room>
    {
        public RoomIsDelibleValidation()
        {
            AddSpecification(new RoomStatusShouldBeCreatedSpec());
        }
    }
}