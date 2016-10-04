using Auctionata.Application.AutoMapper;

namespace Auctionata.Application.Entities.Extensions
{
    public static class RoomExtentions
    {
        public static Domain.Entities.Room ToModel(this Room vm)
        {
            return Mapper.Map<Domain.Entities.Room>(vm);
        }
        public static Room ToViewModel(this Domain.Entities.Room model)
        {
            return Mapper.Map<Room>(model);
        }
    }
}