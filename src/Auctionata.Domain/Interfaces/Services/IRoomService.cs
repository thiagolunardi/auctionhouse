using System;
using System.Collections.Generic;
using Auctionata.Domain.Entities;
using Auctionata.Domain.Entities.Types;
using Auctionata.Domain.Validation;

namespace Auctionata.Domain.Interfaces.Services
{
    public interface IRoomService
    {
        Room Get(Guid id);
        IEnumerable<Room> FindByStatus(RoomStatus status);

        ValidationResult Add(Room room);
        ValidationResult Update(Room room);
        ValidationResult Delete(Room room);
    }
}