using System;
using System.Collections.Generic;
using System.Linq;
using Auctionata.Domain.Entities;
using Auctionata.Domain.Entities.Types;
using Auctionata.Domain.Entities.Validations;
using Auctionata.Domain.Interfaces.Repository;
using Auctionata.Domain.Interfaces.Services;
using Auctionata.Domain.Queries;
using Auctionata.Domain.Validation;

namespace Auctionata.Domain.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _repository;
        private readonly ValidationResult _validationResult = new ValidationResult();

        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }

        public Item Get(Guid id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Item> FindByStatus(ItemStatus status)
        {
            return _repository.Find(ItemQueries.FindByStatus(status)).ToList();
        }

        public ValidationResult Add(Item item)
        {
            if (!item.IsValid)
                return item.ValidationErrors.ToValidationResult();

            _validationResult.Entity = _repository.Add(item);
            return _validationResult;
        }

        public ValidationResult Update(Item item)
        {
            if (!item.IsValid)
                return item.ValidationErrors.ToValidationResult();

            _validationResult.Entity = _repository.Update(item);
            return _validationResult;
        }

        public ValidationResult Delete(Item item)
        {
            var deleteFiscal = new ItemIsDelibleValidation();
            var result = deleteFiscal.Valid(item);
            if (!result.IsValid) return result.Errors.ToValidationResult();

            _repository.Delete(item);
            return _validationResult;
        }
    }
}