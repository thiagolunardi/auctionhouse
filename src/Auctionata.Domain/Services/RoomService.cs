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
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;
        private readonly ValidationResult _validationResult = new ValidationResult();

        public RoomService(IRoomRepository repository)
        {
            _repository = repository;
        }

        public Room Get(Guid id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Room> FindByStatus(RoomStatus status)
        {
            return _repository.Find(RoomQueries.FindByStatus(status)).ToList();
        }

        public ValidationResult Add(Room room)
        {
            if (!room.IsValid)
                return room.ValidationErrors.ToValidationResult();

            _validationResult.Entity = _repository.Add(room);
            return _validationResult;
        }

        public ValidationResult Update(Room room)
        {
            if (!room.IsValid)
                return room.ValidationErrors.ToValidationResult();

            _validationResult.Entity = _repository.Update(room);
            return _validationResult;
        }

        public ValidationResult Delete(Room room)
        {
            var deleteFiscal = new RoomIsDelibleValidation();
            var result = deleteFiscal.Valid(room);
            if (!result.IsValid) return result.Errors.ToValidationResult();

            _repository.Delete(room);
            return _validationResult;
        }
    }
}