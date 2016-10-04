using System.Linq;
using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Entities.Validations.Specifications.RoomSpecs
{
    public class RoomShouldHaveOneOrMoreRangesSpec : ISpecification<Room>
    {
        public string ErrorMessage { get; private set; }

        public bool IsSatisfiedBy(Room room)
        {
            var isSatisfiedBy = room.IncrementalRules.Any();

            if (!isSatisfiedBy)
                ErrorMessage = string.Format(SpecificationMessages.DataIsRequired, SpecificationMessages.IncrementalRanges);

            return isSatisfiedBy;
        }
    }
}