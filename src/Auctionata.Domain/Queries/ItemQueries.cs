using System;
using System.Linq.Expressions;
using Auctionata.Domain.Entities;
using Auctionata.Domain.Entities.Types;

namespace Auctionata.Domain.Queries
{
    public static class ItemQueries
    {
        public static Expression<Func<Item, bool>> FindByStatus(ItemStatus status)
        {
            return item => item.Status == status;
        }
    }
}