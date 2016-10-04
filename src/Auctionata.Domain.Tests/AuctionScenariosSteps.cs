using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Auctionata.Domain.Entities;
using Auctionata.Domain.Entities.Types;
using Auctionata.Domain.Tests.Fakes;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Auctionata.Domain.Tests
{
    [Binding]
    public class AuctionScenariosSteps : MockupData
    {
        private readonly Buyer _me;
        private readonly Room _auctionRoom;
        private Bid _myBid;
        private readonly IEnumerable<Bid> _previousBids;
        private readonly decimal _startingBid;

        public AuctionScenariosSteps()
        {
            _me = Buyers.Single(buyer => buyer.Name == "Thiago Lunardi");
            _auctionRoom = Rooms.Single(room => room.RoomNumber == 7);

            _startingBid = _auctionRoom.NextPrice();

            var attendants = Buyers.Where(b => b.Name != _me.Name).ToList();
            attendants.ForEach(a => _auctionRoom.TryEnterAsAttendant(a));

            _previousBids = attendants.Select(a => a.CreateBid(_auctionRoom, _startingBid, BidType.Online));
            Thread.Sleep(1500); // To be clear that any bid after here will be a lazy bid
        }

        [Given(@"I am in the auction room")]
        public void GivenIAmInTheAuctionRoom()
        {
            var success = _auctionRoom.TryEnterAsAttendant(_me);
            Assert.True(success);
        }
        
        [Then(@"I see the current item picture, description and name")]
        public void ThenISeeTheCurrentItemPictureDescriptionAndName()
        {
            var currentItem = _auctionRoom.CurrentItem;

            Assert.IsNotNull(currentItem);
            Assert.AreEqual(currentItem.ItemNumber, 33);
            Assert.AreEqual(currentItem.Name, "Important Patek Philippe Men's Watch, Switzerland, 1953-60");
            Assert.AreEqual(currentItem.MoreAboutThisItem, "One of rare and popular swiss manufactue, golden case 18k, more than 15yo");
            Assert.AreEqual(currentItem.Picture, "https://d2c2dsgt13elzw.cloudfront.net/resources/300x300/c2/64/d5ee-7c43-408c-9959-a42f4b431c19.jpg");
        }
        
        [Then(@"I see the current highest bid with a button to place a new bid")]
        public void ThenISeeTheCurrentHighestBidWithAButtonToPlaceANewBid()
        {
            // To display the bid button
            // The auction room should be running
            Assert.AreEqual(_auctionRoom.Status, RoomStatus.InAuction);
            // I need to be one of the attendants
            Assert.True(_auctionRoom.Attendants.Any(attendant => attendant.Name == "Thiago Lunardi"));
        }

        [Then(@"I place a bid on an item")]
        public void ThenIPlaceABidOnAnItem()
        {
            // This amount is received by presentation layer
            _myBid = _me.CreateBid(_auctionRoom, _auctionRoom.NextPrice(), BidType.Online);
            Assert.IsNotNull(_myBid);
        }

        [Then(@"I am the only bidder")]
        public void ThenIAmTheOnlyBidder()
        {
            var success = _auctionRoom.TryPlaceBid(_myBid);
            Assert.IsTrue(success);

            var highetsBid = _auctionRoom.Bids.Max(bid => bid.Amount);
            var bids = _auctionRoom.Bids.Where(b => b.Amount == highetsBid).ToList();

            Assert.IsTrue(bids.Count == 1);
        }


        [Then(@"I am not the only bidder")]
        public void ThenIAmNotTheOnlyBidder()
        {
            // ignore
        }

        [Then(@"my bid was placed first")]
        public void ThenMyBidWasPlacedFirst()
        {
            var success = _auctionRoom.TryPlaceBid(_myBid);
            Assert.IsTrue(success);

            Thread.Sleep(1500); // To be clear that any bid after here will be a lazy bid

            var lazyBids = Buyers.Where(b => b.Name != _me.Name).Select(a=>a.CreateBid(_auctionRoom, _startingBid, BidType.Online));
            foreach (var bid in lazyBids)
            {
                success = _auctionRoom.TryPlaceBid(bid);
                Assert.IsTrue(success);
            }
        }

        [Then(@"my bid was not placed first")]
        public void ThenMyBidWasNotPlacedFirst()
        {
            foreach (var bid in _previousBids)
            {
                var success = _auctionRoom.TryPlaceBid(bid);
                Assert.IsTrue(success);
            }
        }

        [Then(@"I am the highest bidder")]
        public void ThenIAmTheHighestBidder()
        {
            var highestBid = _auctionRoom.Bids.OrderByDescending(bid => bid.Amount).First();
            Assert.AreEqual(highestBid.Buyer.Name, _me.Name);
        }


        [Then(@"I am not the highest bidder")]
        public void ThenIAmNotTheHighestBidder()
        {
            var highestFirstBid = _auctionRoom.HighestFirstBid;
            Assert.AreNotEqual(_me.Name, highestFirstBid.Buyer.Name);
        }
    }
}
