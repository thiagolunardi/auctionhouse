using System;
using System.Collections.Generic;
using System.Linq;
using Auctionata.Application.Common;
using Auctionata.Application.Entities.Extensions;
using Auctionata.Application.Entities.Types;
using Auctionata.Application.Interfaces;
using Auctionata.Application.Validation;
using Auctionata.Domain.Entities;
using Auctionata.Domain.Interfaces.Services;
using Auctionata.Infra.Data.Context;
using Auctionata.Infra.Data.Context.Interfaces;
using BidType = Auctionata.Domain.Entities.Types.BidType;
using Room = Auctionata.Application.Entities.Room;
using ValidationExtensions = Auctionata.Domain.Validation.ValidationExtensions;


namespace Auctionata.Application
{
    public class RoomAppService: AppService<MainContext>, IRoomAppService
    {
        private readonly IRoomService _roomService;
        private readonly IBuyerService _buyerService;

        public RoomAppService(IRoomService roomService, IBuyerService buyerService, IUnitOfWork<MainContext> uow) : base(uow)
        {
            _roomService = roomService;
            _buyerService = buyerService;
        }

        public Room Get(Guid id)
        {
            var roomModel = _roomService.Get(id);
            return roomModel.ToViewModel();
        }

        public ValidationResult PlaceABid(string bidderName, string roomId, decimal bidAmount)
        {
            var guid = new Guid(roomId);
            var room = _roomService.Get(guid);

            var bidder = _buyerService.FindByName(bidderName).First();

            var bid = new Bid(room, bidder, bidAmount, BidType.Online);

            BeginTransaction();

            ValidationResult = !room.TryPlaceBid(bid) 
                ? ValidationExtensions.ToValidationResult(room.ValidationErrors).ToViewModel() 
                : _roomService.Update(room).ToViewModel();

            if(ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public IEnumerable<Room> FindByStatus(RoomStatus status)
        {
            var roomsModel = _roomService.FindByStatus(status.ToModel());
            return roomsModel.Select(room => room.ToViewModel());
        }

        public ValidationResult Add(Room room)
        {
            BeginTransaction();

            var roomModel = room.ToModel();
            ValidationResult = _roomService.Add(roomModel).ToViewModel();

            if (ValidationResult.IsValid) Commit();
            return ValidationResult;
        }

        public ValidationResult Update(Room room)
        {
            BeginTransaction();

            var roomModel = room.ToModel();
            ValidationResult = _roomService.Update(roomModel).ToViewModel();

            if (ValidationResult.IsValid) Commit();
            return ValidationResult;
        }

        public ValidationResult Delete(Room room)
        {
            BeginTransaction();

            var roomModel = room.ToModel();
            ValidationResult = _roomService.Delete(roomModel).ToViewModel();

            if (ValidationResult.IsValid) Commit();
            return ValidationResult;
        }
    }
}