using Auctionata.Application.Entities.Types;

namespace Auctionata.Application.Entities.Extensions
{
    public static class BidTypeExtensions
    {
        public static Domain.Entities.Types.BidType ToModel(this BidType type)
        {
            return (Domain.Entities.Types.BidType) type;
        }
    }
}