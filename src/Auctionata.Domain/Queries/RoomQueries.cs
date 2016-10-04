using System;
using System.Linq.Expressions;
using Auctionata.Domain.Entities;
using Auctionata.Domain.Entities.Types;

namespace Auctionata.Domain.Queries
{
    public static class RoomQueries
    {
        public static Expression<Func<Room, bool>> FindByStatus(RoomStatus status)
        {
            return room => room.Status == status;
        }
    }
}