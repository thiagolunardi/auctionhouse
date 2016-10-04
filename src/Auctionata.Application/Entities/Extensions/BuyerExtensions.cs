using Auctionata.Application.AutoMapper;

namespace Auctionata.Application.Entities.Extensions
{
    public static class BuyerExtentions
    {
        public static Domain.Entities.Buyer ToModel(this Buyer vm)
        {
            return Mapper.Map<Domain.Entities.Buyer>(vm);
        }
        public static Buyer ToViewModel(this Domain.Entities.Buyer model)
        {
            return Mapper.Map<Buyer>(model);
        }
    }
}