using System.Collections.Generic;
using System.Linq;
using Auctionata.Domain.Entities;

namespace Auctionata.Domain.Tests.Fakes
{
    public abstract class MockupData
    {
        public IEnumerable<Bid> Bids { get; set; }
        public IEnumerable<Buyer> Buyers { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<Room> Rooms { get; set; }

        protected MockupData()
        {
            Buyers = new[]
            {
                new Buyer("Thiago Lunardi", "Brazil"),
                new Buyer("Martin Pernecky", "Slovak"),
                new Buyer("Artashes Torosyan", "Germany"),
                new Buyer("Edward Shenderovich", "United States"),
                new Buyer("Marta Olszewska", "United Kingdon"),
                new Buyer("Eldar Djafarov", "Ukraine"),
            };

            Items = new[]
            {
                new Item(33,
                    "Important Patek Philippe Men's Watch, Switzerland, 1953-60",
                    "Luxury Watches, Pocket Watches, Wrist Watches",
                    "https://d2c2dsgt13elzw.cloudfront.net/resources/300x300/c2/64/d5ee-7c43-408c-9959-a42f4b431c19.jpg",
                    "One of rare and popular swiss manufactue, golden case 18k, more than 15yo", 
                    180000m, 360000m)
            };

            var item = Items.Single(i => i.ItemNumber == 33);
            Rooms = new[]
            {
                new Room(7, "https://auctionata.com/assets/videos/Lot_8197-1_NR7_LOT_33_en.webm")
            };

            var room = Rooms.Single(r => r.RoomNumber == 7);

            room.TryAddItem(item);
            
            room.TryAddNewIncrementalRange(new IncrementalRule {MinimumItemValue = 180000m, Increment = 10000m});
            room.TryAddNewIncrementalRange(new IncrementalRule { MinimumItemValue = 200000m, Increment = 20000m });

            room.TryStartAuction();
        }
    }
}