using Auctionata.Application.Entities;
using Auctionata.Application.Entities.Types;
using Auctionata.Application.Validation;
using AutoMapper;

namespace Auctionata.Application.AutoMapper
{
    public class ModelToViewModelProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Domain.Validation.ValidationError, ValidationError>();
            CreateMap<Domain.Validation.ValidationResult, ValidationResult>();

            CreateMap<Domain.Entities.Bid, Bid>();
            CreateMap<Domain.Entities.Buyer, Buyer>();
            CreateMap<Domain.Entities.IncrementalRule, IncrementalRule>();
            CreateMap<Domain.Entities.Item, Item>();
            CreateMap<Domain.Entities.Types.ItemStatus, ItemStatus>();
            CreateMap<Domain.Entities.Room, Room>();
            CreateMap<Domain.Entities.Types.RoomStatus, RoomStatus>();
        }
    }
}