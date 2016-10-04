using System;
using Auctionata.Application.Entities;
using Auctionata.Application.Validation;

namespace Auctionata.Application.Interfaces
{
    public interface IRoomAppService
    {
        Room Get(Guid id);
        ValidationResult PlaceABid(string bidderName, string roomId, decimal bidAmount);
    }
}