using System;
using System.Collections.Generic;
using System.Linq;
using Auctionata.Application.Common;
using Auctionata.Application.Entities;
using Auctionata.Application.Entities.Extensions;
using Auctionata.Application.Interfaces;
using Auctionata.Application.Validation;
using Auctionata.Domain.Interfaces.Services;
using Auctionata.Infra.Data.Context;
using Auctionata.Infra.Data.Context.Interfaces;

namespace Auctionata.Application
{
    public class BuyerAppService : AppService<MainContext>, IBuyerAppService
    {
        private readonly IBuyerService _buyerService;

        public BuyerAppService(IBuyerService buyerService, IUnitOfWork<MainContext> uow) : base(uow)
        {
            _buyerService = buyerService;
        }

        public Buyer Get(Guid id)
        {
            var buyerModel = _buyerService.Get(id);
            return buyerModel.ToViewModel();
        }

        public IEnumerable<Buyer> FindByName(string name)
        {
            var buyersModel = _buyerService.FindByName(name);
            return buyersModel.Select(buyer => buyer.ToViewModel());
        }

        public IEnumerable<Buyer> FindByCountry(string country)
        {
            var buyersModel = _buyerService.FindByCountry(country);
            return buyersModel.Select(buyer => buyer.ToViewModel());
        }

        public ValidationResult Add(Buyer buyer)
        {
            BeginTransaction();

            var buyerModel = buyer.ToModel();
            ValidationResult = _buyerService.Add(buyerModel).ToViewModel();

            if(ValidationResult.IsValid) Commit();
            return ValidationResult;
        }

        public ValidationResult Update(Buyer buyer)
        {
            BeginTransaction();

            var buyerModel = buyer.ToModel();
            ValidationResult = _buyerService.Update(buyerModel).ToViewModel();

            if (ValidationResult.IsValid) Commit();
            return ValidationResult;
        }
    }
}