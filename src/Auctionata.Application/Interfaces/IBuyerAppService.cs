using System;
using System.Collections.Generic;
using Auctionata.Application.Entities;
using Auctionata.Application.Validation;

namespace Auctionata.Application.Interfaces
{
    public interface IBuyerAppService
    {
        Buyer Get(Guid id);
        IEnumerable<Buyer> FindByName(string name);
        IEnumerable<Buyer> FindByCountry(string country);

        ValidationResult Add(Buyer buyer);
        ValidationResult Update(Buyer buyer);
    }
}