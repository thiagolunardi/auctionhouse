using Auctionata.Infra.Data.Context.Interfaces;

namespace Auctionata.Application.Interfaces.Common
{
    public interface IAppService<TContext>
        where TContext : IDbContext, new()
    {
        void BeginTransaction();
        void Commit();
    }
}