using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Entities.Validations.Specifications.RoomSpecs
{
    public class RoomNumberShouldbeGraterThanZeroSpec : ISpecification<Room>
    {
        public string ErrorMessage { get; private set; }

        public bool IsSatisfiedBy(Room room)
        {
            var isSatisfiedBy = room.RoomNumber > 0;

            if (!isSatisfiedBy)
                ErrorMessage = string.Format(SpecificationMessages.DataShoudBeGreaterThan, SpecificationMessages.RoomNumber, 0);

            return isSatisfiedBy;
        }
    }
}