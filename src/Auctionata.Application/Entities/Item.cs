using System;
using Auctionata.Application.Entities.Common;
using Auctionata.Application.Entities.Types;

namespace Auctionata.Application.Entities
{
    public class Item : Identity
    {
        /// <summary>
        /// Item number inside the room auction session
        /// </summary>
        public int ItemNumber { get; set; }

        /// <summary>
        /// Item name, brand or model
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Category description
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// URL of product item
        /// </summary>
        public string Picture { get; }

        /// <summary>
        /// More detailed information about the product item
        /// </summary>
        public string MoreAboutThisItem { get; }

        /// <summary>
        /// Minimum starting bid
        /// </summary>
        public decimal StartingBid { get; }

        /// <summary>
        /// The highest value expected, but not limited to
        /// </summary>
        public decimal Estimate { get; }

        /// <summary>
        /// Current Item status
        /// </summary>
        public ItemStatus Status { get; private set; }

        /// <summary>
        /// Create a new item to be auctioned
        /// </summary>
        /// <param name="itemNumber">Item number inside the room auction session</param>
        /// <param name="name">Item name, brand or model</param>
        /// <param name="category">Category description</param>
        /// <param name="picture">URL of product item</param>
        /// <param name="moreAboutThisItem">More detailed information about the product item</param>
        /// <param name="startingBid">Minimun starting bid</param>
        /// <param name="estimate">The highest value expected, but not limited to</param>
        public Item(int itemNumber, string name, string category, string picture, string moreAboutThisItem, decimal startingBid, decimal estimate)
        {
            Id = Guid.NewGuid();
            ItemNumber = itemNumber;
            Name = name;
            Category = category;
            Picture = picture;
            MoreAboutThisItem = moreAboutThisItem;
            StartingBid = startingBid;
            Estimate = estimate;
            Status = ItemStatus.ToBeAuctioned;
        }
    }
}
