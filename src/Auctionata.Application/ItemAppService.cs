using System;
using System.Collections.Generic;
using System.Linq;
using Auctionata.Application.Common;
using Auctionata.Application.Entities;
using Auctionata.Application.Entities.Extensions;
using Auctionata.Application.Entities.Types;
using Auctionata.Application.Interfaces;
using Auctionata.Application.Validation;
using Auctionata.Domain.Interfaces.Services;
using Auctionata.Infra.Data.Context;
using Auctionata.Infra.Data.Context.Interfaces;

namespace Auctionata.Application
{
    public class ItemAppService: AppService<MainContext>, IItemAppService
    {
        private readonly IItemService _itemService;

        public ItemAppService(IItemService itemService, IUnitOfWork<MainContext> uow) : base(uow)
        {
            _itemService = itemService;
        }

        public Item Get(Guid id)
        {
            var itemModel = _itemService.Get(id);
            return itemModel.ToViewModel();
        }

        public IEnumerable<Item> FindByStatus(ItemStatus status)
        {
            var itemsModel = _itemService.FindByStatus(status.ToModel());
            return itemsModel.Select(item => item.ToViewModel());
        }

        public ValidationResult Add(Item item)
        {
            BeginTransaction();

            var itemModel = item.ToModel();
            ValidationResult = _itemService.Add(itemModel).ToViewModel();

            if (ValidationResult.IsValid) Commit();
            return ValidationResult;
        }

        public ValidationResult Update(Item item)
        {
            BeginTransaction();

            var itemModel = item.ToModel();
            ValidationResult = _itemService.Update(itemModel).ToViewModel();

            if (ValidationResult.IsValid) Commit();
            return ValidationResult;
        }

        public ValidationResult Delete(Item item)
        {
            BeginTransaction();

            var itemModel = item.ToModel();
            ValidationResult = _itemService.Delete(itemModel).ToViewModel();

            if (ValidationResult.IsValid) Commit();
            return ValidationResult;
        }
    }
}