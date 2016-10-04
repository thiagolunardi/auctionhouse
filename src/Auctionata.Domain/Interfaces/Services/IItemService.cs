using System;
using System.Collections.Generic;
using Auctionata.Domain.Entities;
using Auctionata.Domain.Entities.Types;
using Auctionata.Domain.Validation;

namespace Auctionata.Domain.Interfaces.Services
{
    public interface IItemService
    {
        Item Get(Guid id);
        IEnumerable<Item> FindByStatus(ItemStatus status);

        ValidationResult Add(Item item);
        ValidationResult Update(Item item);
        ValidationResult Delete(Item item);
    }
}