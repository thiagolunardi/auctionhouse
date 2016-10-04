using System.Linq;
using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Entities.Validations.Specifications.RoomSpecs
{
    public class RoomIncrementalRangesShouldAllBeValidSpec : ISpecification<Room>
    {
        public string ErrorMessage { get; private set; }

        public bool IsSatisfiedBy(Room room)
        {
            var isSatisfiedBy = room.IncrementalRules.All(r => r.IsValid);

            if (!isSatisfiedBy)
                ErrorMessage = string.Format(SpecificationMessages.SomeDataIsInvalid, SpecificationMessages.IncrementalRange);

            return isSatisfiedBy;
        }
    }
}