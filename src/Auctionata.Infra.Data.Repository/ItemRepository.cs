using Auctionata.Domain.Entities;
using Auctionata.Domain.Interfaces.Repository;
using Auctionata.Infra.Data.Common;
using Auctionata.Infra.Data.Context;
using Auctionata.Infra.Data.Context.Interfaces;

namespace Auctionata.Infra.Data
{
    public class ItemRepository : Repository<Item, MainContext>, IItemRepository
    {
        public ItemRepository(IContextManager<MainContext> contextManager) : base(contextManager)
        {
        }
    }
}