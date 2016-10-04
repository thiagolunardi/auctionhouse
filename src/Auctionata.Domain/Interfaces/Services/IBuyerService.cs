using System;
using System.Collections.Generic;
using Auctionata.Domain.Entities;
using Auctionata.Domain.Validation;

namespace Auctionata.Domain.Interfaces.Services
{
    public interface IBuyerService
    {
        Buyer Get(Guid id);
        IEnumerable<Buyer> FindByName(string name);
        IEnumerable<Buyer> FindByCountry(string country);

        ValidationResult Add(Buyer buyer);
        ValidationResult Update(Buyer buyer);
    }
}