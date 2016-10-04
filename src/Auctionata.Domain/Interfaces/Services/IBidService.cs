using Auctionata.Domain.Entities;
using Auctionata.Domain.Validation;

namespace Auctionata.Domain.Interfaces.Services
{
    public interface IBidService
    {
        ValidationResult Add(Bid bid);
    }
}