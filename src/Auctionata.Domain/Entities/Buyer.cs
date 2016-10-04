using System;
using Auctionata.Domain.Entities.Common;
using Auctionata.Domain.Entities.Types;
using Auctionata.Domain.Entities.Validations;
using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Entities
{
    /// <summary>
    /// Person able to send bids
    /// </summary>
    public class Buyer : Identity, ISelfValidation
    {
        /// <summary>
        /// Buyer name with surname
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Buyer country location
        /// </summary>
        public string Country { get; }

        /// <summary>
        /// Create a buyer identified by name and country
        /// </summary>
        /// <param name="name">Buyer name with surname</param>
        /// <param name="country">Buyer country location</param>
        public Buyer(string name, string country)
        {
            Id = Guid.NewGuid();
            Name = name;
            Country = country;
        }
        
        public override bool IsValid
        {
            get
            {
                var fiscal = new BuyerIsValidValidation();
                var result = fiscal.Valid(this);

                ValidationErrors = result.Errors;
                return result.IsValid;
            }
        }

        public Bid CreateBid(Room room, decimal bidAmount, BidType type)
        {
            return new Bid(room, this, bidAmount, type);
        }
    }
}