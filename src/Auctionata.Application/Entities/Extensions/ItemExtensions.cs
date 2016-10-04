using Auctionata.Application.AutoMapper;

namespace Auctionata.Application.Entities.Extensions
{
    public static class ItemExtentions
    {
        public static Domain.Entities.Item ToModel(this Item vm)
        {
            return Mapper.Map<Domain.Entities.Item>(vm);
        }
        public static Item ToViewModel(this Domain.Entities.Item model)
        {
            return Mapper.Map<Item>(model);
        }
    }
}