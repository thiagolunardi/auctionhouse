using Auctionata.Domain.Entities.Validations.Specifications.RoomSpecs;
using Auctionata.Domain.Specification;

namespace Auctionata.Domain.Entities.Validations
{
    public sealed class RoomIsValidValidation : Inspector<Room>
    {
        public RoomIsValidValidation()
        {
            AddSpecification(new RoomNumberShouldbeGraterThanZeroSpec());
            AddSpecification(new RoomShouldHaveVideoStreamingEndpointSpec());
        }
    }
}