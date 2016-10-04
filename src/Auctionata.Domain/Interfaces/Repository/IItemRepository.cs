using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Auctionata.Domain.Entities;

namespace Auctionata.Domain.Interfaces.Repository
{
    public interface IItemRepository
    {
        Item Get(Guid id);
        IEnumerable<Item> Find(Expression<Func<Item, bool>> predicate);

        Item Add(Item item);
        Item Update(Item item);
        Item Delete(Item item);
    }
}