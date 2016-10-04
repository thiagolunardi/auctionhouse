using System;
using System.Collections.Generic;
using System.Linq;
using Auctionata.Domain.Entities.Common;
using Auctionata.Domain.Entities.Types;
using Auctionata.Domain.Entities.Validations;
using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Entities
{
    /// <summary>
    /// The place that will host all item auction and manage bids
    /// </summary>
    public class Room : Identity, ISelfValidation
    {
        /// <summary>
        /// The item that will be auctioned in this room
        /// </summary>
        public IEnumerable<Item> Items { get; private set; }

        /// <summary>
        /// The current room number
        /// </summary>
        public int RoomNumber { get; }
        /// <summary>
        /// The URL to play the item auction video broadcast 
        /// </summary>
        public string VideoStreamingEndpoint { get; }
        /// <summary>
        /// The current room status
        /// </summary>
        public  RoomStatus Status { get; private set; }

        /// <summary>
        /// All bids that was bidded during this room
        /// </summary>
        public virtual IEnumerable<Bid> Bids { get; private set; }
        
        /// <summary>
        /// The incremental rules that will be applied at this room
        /// </summary>
        public virtual IEnumerable<IncrementalRule> IncrementalRules { get; protected set; }

        /// <summary>
        /// Whom is attending this auction room
        /// </summary>
        public virtual IEnumerable<Buyer> Attendants { get; protected set; }

        public Item CurrentItem => Items
            .Where(item => item.Status == ItemStatus.InAuction)
            .OrderBy(item => item.ItemNumber)
            .FirstOrDefault();

        public Bid HighestFirstBid => Bids
            .OrderByDescending(bid => bid.Amount)
            .ThenBy(bid => bid.Date)
            .FirstOrDefault();

        /// <summary>
        /// Calculate the next minimum bid
        /// </summary>
        /// <returns>Minimum bid amount</returns>
        public decimal NextPrice()
        {
            if (!Bids.Any())
                return CurrentItem.StartingBid;

            var nextPrice = Bids.Max(bid => bid.Amount);
            var incrementalRenges = IncrementalRules.OrderByDescending(range => range.MinimumItemValue).ToList();
            incrementalRenges.ForEach(range =>
            {
                if (nextPrice >= range.MinimumItemValue) return;
                nextPrice += range.Increment;
            });
            return nextPrice;
        }

        /// <summary>
        /// Try to add a new buyer into this room
        /// </summary>
        /// <param name="buyer">The new attendant and potential buyer</param>
        /// <returns></returns>
        public bool TryEnterAsAttendant(Buyer buyer)
        {
            var fiscal = new RoomCanReceiveAttendantValidation();
            var result = fiscal.Valid(this);

            if (!result.IsValid)
            {
                ValidationErrors = result.Errors;
                return false;
            }

            var attendants = Attendants.ToList();
            attendants.Add(buyer);
            Attendants = attendants;

            return true;
        }

        /// <summary>
        /// Try to add a new incremental rule into this room
        /// </summary>
        /// <param name="incrementalRule">The new attendant and potential buyer</param>
        /// <returns></returns>
        public bool TryAddNewIncrementalRange(IncrementalRule incrementalRule)
        {
            var fiscal = new RoomCanReceiveNewIncrementalRuleValidation();
            var result = fiscal.Valid(this);

            if (!result.IsValid)
            {
                ValidationErrors = result.Errors;
                return false;
            }

            var incrementalRules = IncrementalRules.ToList();
            incrementalRules.Add(incrementalRule);
            IncrementalRules = incrementalRules;

            return true;
        }

        /// <summary>
        /// Add a new item to this auction room
        /// </summary>
        /// <param name="item">Item to be auctioned</param>
        public bool TryAddItem(Item item)
        {
            var fiscal = new RoomCanAddItemValidation();
            var result = fiscal.Valid(this);

            if (!result.IsValid)
            {
                ValidationErrors = result.Errors;
                return false;
            }

            var items = Items.ToList();
            items.Add(item);
            Items = items;

            return true;
        }

        /// <summary>
        /// Try to begin the auction
        /// </summary>
        /// <returns></returns>
        public bool TryStartAuction()
        {
            var fiscal = new RoomCanBeginAnAuctionValidation();
            var result = fiscal.Valid(this);

            if (!result.IsValid)
            {
                ValidationErrors = result.Errors;
                return false;
            }

            Status = RoomStatus.InAuction;

            Items.OrderBy(item => item.ItemNumber).First().TryStartAuction();

            return true;
        }

        /// <summary>
        /// Try to place new bid
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public bool TryPlaceBid(Bid bid)
        {
            var fiscal = new RoomCanPlaceBidValidation();
            var result = fiscal.Valid(this);

            if (!result.IsValid)
            {
                ValidationErrors = result.Errors;
                return false;
            }

            var bids = Bids.ToList();
            bids.Add(bid);
            Bids = bids;

            return true;
        }


        /// <summary>
        /// Create a new auction room session for an Item
        /// </summary>
        /// <param name="roomNumber">Room number for human identification</param>
        /// <param name="videoStreamingEndpoint">URL of video streamin endpoint</param>
        public Room(int roomNumber, string videoStreamingEndpoint)
        {
            Id = Guid.NewGuid();
            RoomNumber = roomNumber;
            VideoStreamingEndpoint = videoStreamingEndpoint;
            Status = RoomStatus.Created;

            IncrementalRules = new List<IncrementalRule>();
            Items = new List<Item>();
            Bids = new List<Bid>();
            Attendants = new List<Buyer>();
        }

        public override bool IsValid
        {
            get
            {
                var fiscal = new RoomIsValidValidation();
                var result = fiscal.Valid(this);

                ValidationErrors = result.Errors;
                return result.IsValid;
            }
       }
    }
}