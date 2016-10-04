using Auctionata.Domain.Entities;

namespace Auctionata.Domain.Interfaces.Repository
{
    public interface IBidRepository
    {
        Bid Add(Bid bid);
    }
}