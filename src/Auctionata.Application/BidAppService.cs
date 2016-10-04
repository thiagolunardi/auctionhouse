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
    public class BidAppService: AppService<MainContext>, IBidAppService
    {
        private readonly IBidService _bidService;

        public BidAppService(IBidService bidService, IUnitOfWork<MainContext> uow) : base(uow)
        {
            _bidService = bidService;
        }


        public ValidationResult Add(Bid bid)
        {
            BeginTransaction();

            var bidModel = bid.ToModel();
            ValidationResult = _bidService.Add(bidModel).ToViewModel();

            if(ValidationResult.IsValid) Commit();
            return ValidationResult;
        }
    }
}