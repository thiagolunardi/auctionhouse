using System;
using System.Collections.Generic;
using System.Linq;
using Auctionata.Application.Entities.Common;
using Auctionata.Application.Entities.Types;

namespace Auctionata.Application.Entities
{
    /// <summary>
    /// The place that will host all item auction and manage bids
    /// </summary>
    public class Room : Identity
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
    }
}