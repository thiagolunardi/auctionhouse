using System.Data.Entity;
using Auctionata.Infra.Data.Context.Interfaces;

namespace Auctionata.Infra.Data.Context
{
    public class MainContext : DbContext, IDbContext
    {
    }
}