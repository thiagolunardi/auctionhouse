using Auctionata.Domain.Entities;
using Auctionata.Domain.Entities.Validations;
using Auctionata.Domain.Interfaces.Repository;
using Auctionata.Domain.Interfaces.Services;
using Auctionata.Domain.Validation;

namespace Auctionata.Domain.Services
{
    public class BidService : IBidService
    {
        private readonly IBidRepository _repository;
        private readonly ValidationResult _validationResult = new ValidationResult();

        public BidService(IBidRepository repository)
        {
            _repository = repository;
        }

        public ValidationResult Add(Bid bid)
        {
            // Check if this is a valid bid
            if (!bid.IsValid)
                return bid.ValidationErrors.ToValidationResult();

            // Check if this bid can be given
            var addFiscal = new BidCanBeGivenValidation();
            var result = addFiscal.Valid(bid);
            if (!result.IsValid) return result.Errors.ToValidationResult();

            _validationResult.Entity = _repository.Add(bid);
            return _validationResult;
        }
    }
}