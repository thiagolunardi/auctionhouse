using System;
using System.Linq.Expressions;
using Auctionata.Domain.Entities;

namespace Auctionata.Domain.Queries
{
    public static class BuyerQueries
    {
        public static Expression<Func<Buyer, bool>> FindByName(string name)
        {
            return buyer => buyer.Name == name;
        }

        public static Expression<Func<Buyer, bool>> FindByCountry(string country)
        {
            return buyer => buyer.Name == country;
        }
    }
}