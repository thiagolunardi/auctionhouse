using Auctionata.Application.Entities;
using AutoMapper;

namespace Auctionata.Application.AutoMapper
{
    public class ViewModelToModelProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Bid, Domain.Entities.Bid>();
            CreateMap<Buyer, Domain.Entities.Buyer>();
            CreateMap<IncrementalRule, Domain.Entities.IncrementalRule>();
            CreateMap<Item, Domain.Entities.Item>();
            CreateMap<Room, Domain.Entities.Room>();
        }
    }
}