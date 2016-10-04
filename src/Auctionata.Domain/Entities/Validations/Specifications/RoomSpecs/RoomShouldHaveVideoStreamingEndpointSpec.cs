using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Entities.Validations.Specifications.RoomSpecs
{
    public class RoomShouldHaveVideoStreamingEndpointSpec : ISpecification<Room>
    {
        public string ErrorMessage { get; private set; }

        public bool IsSatisfiedBy(Room room)
        {
            var isSatisfiedBy = !string.IsNullOrEmpty(room.VideoStreamingEndpoint);

            if (!isSatisfiedBy)
                ErrorMessage = string.Format(SpecificationMessages.DataIsRequired, SpecificationMessages.VideoStreamingEndpoint);

            return isSatisfiedBy;
        }
    }
}