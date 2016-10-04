using System;
using Auctionata.Domain.Entities.Common;
using Auctionata.Domain.Entities.Types;
using Auctionata.Domain.Entities.Validations;
using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Entities
{
    /// <summary>
    /// A concrete bid given during a item auction
    /// </summary>
    public class Bid : Identity, ISelfValidation
    {
        /// <summary>
        /// Auction Room Session
        /// </summary>
        public Room Room { get; }
        /// <summary>
        /// Who is given the bid
        /// </summary>
        public Buyer Buyer { get; }
        /// <summary>
        /// Bid Amount given by the buyer
        /// </summary>
        public decimal Amount { get; }
        /// <summary>
        /// Date and time UTC of bid
        /// </summary>
        public DateTimeOffset Date { get; }

        /// <summary>
        /// Bid placed by telephone or online
        /// </summary>
        public BidType Type { get; }

        /// <summary>
        /// Create a Bid to be commited to a
        /// </summary>
        /// <param name="room">Room that bid will be placed</param>
        /// <param name="buyer">Buyer owner of this bid</param>
        /// <param name="amount">Bid amount to be commited</param>
        public Bid(Room room, Buyer buyer, decimal amount, BidType type)
        {
            Id = Guid.NewGuid();
            Date = DateTimeOffset.UtcNow;
            Room = room;
            Buyer = buyer;
            Amount = amount;
            Type = type;
        }

        public override bool IsValid
        {
            get
            {
                var fiscal = new BidIsValidValidation();
                var result = fiscal.Valid(this);

                ValidationErrors = result.Errors;
                return result.IsValid;
            }
        }
    }
}