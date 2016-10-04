using Auctionata.Application.Entities.Types;

namespace Auctionata.Application.Entities.Extensions
{
    public static class ItemStatusExtensions
    {
        public static Domain.Entities.Types.ItemStatus ToModel(this ItemStatus status)
        {
            return (Domain.Entities.Types.ItemStatus) status;
        }
    }
}