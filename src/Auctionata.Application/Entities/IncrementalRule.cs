using Auctionata.Application.Entities.Common;

namespace Auctionata.Application.Entities
{
    /// <summary>
    /// Rules list to guide the auction product item price Incremental
    /// </summary>
    public class IncrementalRule : Identity
    {
        /// <summary>
        /// Minimum value to apply the increment
        /// </summary>
        public decimal MinimumItemValue { get; set; }
        /// <summary>
        /// Amount that should be incremented after the first bid
        /// </summary>
        public decimal Increment { get; set; }
    }
}