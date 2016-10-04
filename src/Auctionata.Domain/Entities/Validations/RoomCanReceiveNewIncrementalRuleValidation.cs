using Auctionata.Domain.Entities.Validations.Specifications.RoomSpecs;
using Auctionata.Domain.Specification;

namespace Auctionata.Domain.Entities.Validations
{
    public sealed class RoomCanReceiveNewIncrementalRuleValidation : Inspector<Room>
    {
        public RoomCanReceiveNewIncrementalRuleValidation()
        {
            AddSpecification(new RoomStatusShouldBeCreatedSpec());
        }
    }
}