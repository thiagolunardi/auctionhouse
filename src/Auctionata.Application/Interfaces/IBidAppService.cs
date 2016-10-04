using Auctionata.Application.Entities;
using Auctionata.Application.Validation;

namespace Auctionata.Application.Interfaces
{
    public interface IBidAppService
    {
        ValidationResult Add(Bid bid);
    }
}