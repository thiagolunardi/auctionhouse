using Auctionata.Application.AutoMapper;

namespace Auctionata.Application.Entities.Extensions
{
    public static class BidExtentions
    {
        public static Domain.Entities.Bid ToModel(this Bid vm)
        {
            return Mapper.Map<Domain.Entities.Bid>(vm);
        }
        public static Bid ToViewModel(this Domain.Entities.Bid model)
        {
            return Mapper.Map<Bid>(model);
        }
    }
}