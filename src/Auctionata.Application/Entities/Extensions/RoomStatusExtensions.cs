using Auctionata.Application.Entities.Types;

namespace Auctionata.Application.Entities.Extensions
{
    public static class RoomStatusExtensions
    {
        public static Domain.Entities.Types.RoomStatus ToModel(this RoomStatus status)
        {
            return (Domain.Entities.Types.RoomStatus) status;
        }
    }
}