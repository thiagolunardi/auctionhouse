using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Auctionata.Domain.Entities;

namespace Auctionata.Domain.Interfaces.Repository
{
    public interface IRoomRepository
    {
        Room Get(Guid id);
        IEnumerable<Room> Find(Expression<Func<Room, bool>> predicate);

        Room Add(Room item);
        Room Update(Room item);
        Room Delete(Room item);
    }
}