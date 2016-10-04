using Auctionata.Application.Entities;

namespace Auctionata.Presentation.WebAPI.ViewModels
{
    public class HighestBidViewModel
    {
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public Buyer Bidder { get; set; }

        public static HighestBidViewModel ToViewModel(Bid bid)
        {
            return new HighestBidViewModel
            {
                Amount = bid.Amount,
                Type = bid.Type.ToString(),
                Bidder = bid.Buyer
            };
        }
    }
}