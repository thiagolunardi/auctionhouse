using System;
using System.Collections.Generic;
using Auctionata.Application.Entities;
using Auctionata.Application.Entities.Types;
using Auctionata.Application.Validation;

namespace Auctionata.Application.Interfaces
{
    public interface IItemAppService
    {
        Item Get(Guid id);
        IEnumerable<Item> FindByStatus(ItemStatus status);

        ValidationResult Add(Item item);
        ValidationResult Update(Item item);
        ValidationResult Delete(Item item);
    }
}