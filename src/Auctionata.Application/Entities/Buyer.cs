using System;
using Auctionata.Application.Entities.Common;
using Auctionata.Application.Entities.Types;

namespace Auctionata.Application.Entities
{
    /// <summary>
    /// Person able to send bids
    /// </summary>
    public class Buyer : Identity
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

        public Bid CreateBid(Room room, decimal bidAmount, BidType type)
        {
            return new Bid(room, this, bidAmount, type);
        }
    }
}