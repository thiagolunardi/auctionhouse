using System;
using System.Collections.Generic;
using System.Linq;
using Auctionata.Domain.Entities;
using Auctionata.Domain.Interfaces.Repository;
using Auctionata.Domain.Interfaces.Services;
using Auctionata.Domain.Queries;
using Auctionata.Domain.Validation;

namespace Auctionata.Domain.Services
{
    public class BuyerService : IBuyerService
    {
        private readonly IBuyerRepository _repository;
        private readonly ValidationResult _validationResult;

        public BuyerService(IBuyerRepository repository)
        {
            _repository = repository;
            _validationResult = new ValidationResult();
        }

        public Buyer Get(Guid id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Buyer> FindByName(string name)
        {
            return _repository.Find(BuyerQueries.FindByName(name)).ToList();
        }

        public IEnumerable<Buyer> FindByCountry(string country)
        {
            return _repository.Find(BuyerQueries.FindByCountry(country)).ToList();
        }

        public ValidationResult Add(Buyer buyer)
        {
            if (!buyer.IsValid)
                return buyer.ValidationErrors.ToValidationResult();

            _validationResult.Entity = _repository.Add(buyer);
            return _validationResult;
        }

        public ValidationResult Update(Buyer buyer)
        {
            if (!buyer.IsValid)
                return buyer.ValidationErrors.ToValidationResult();

            _validationResult.Entity = _repository.Update(buyer);
            return _validationResult;
        }
    }
}