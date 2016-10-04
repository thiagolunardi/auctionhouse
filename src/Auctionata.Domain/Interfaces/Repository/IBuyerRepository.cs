using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Auctionata.Domain.Entities;

namespace Auctionata.Domain.Interfaces.Repository
{
    public interface IBuyerRepository
    {
        Buyer Get(Guid id);
        IEnumerable<Buyer> Find(Expression<Func<Buyer, bool>> predicate);

        Buyer Add(Buyer buyer);
        Buyer Update(Buyer buyer);
        Buyer Delete(Buyer buyer);
    }
}