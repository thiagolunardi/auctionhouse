using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Auctionata.Application.Entities;
using Auctionata.Application.Interfaces;
using Auctionata.Presentation.WebAPI.ViewModels;
using Auctionata.Presentation.WebAPI.ViewModels.Extensions;

namespace Auctionata.Presentation.WebAPI.Controllers
{
    [Authorize]
    public class RoomController : ApiController
    {
        private readonly IRoomAppService _roomAppService;

        public RoomController(IRoomAppService roomAppService)
        {
            _roomAppService = roomAppService;
        }

        /// <summary>
        /// Displaying information about the current room
        /// </summary>
        /// <param name="id">Room ID</param>
        /// <returns>number, status, etc</returns>
        [HttpGet]
        public async Task<Room> Get(string id)
        {
            var guid = new Guid(id);
            var room = _roomAppService.Get(guid);

            return await Task.FromResult(room);
        }

        /// <summary>
        /// Current highest bid
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Amount, bidder</returns>
        [HttpGet]
        [Route("{id}/bid")]
        public async Task<HighestBidViewModel> GetHighestBid(string id)
        {
            var guid = new Guid(id);
            var room = _roomAppService.Get(guid);
            var highestBid = room.HighestFirstBid;

            var vm = HighestBidViewModel.ToViewModel(highestBid);

            return await Task.FromResult(vm);
        }

        /// <summary>
        /// Place a bid
        /// </summary>
        /// <param name="id">Room id</param>
        /// <param name="vm">Bid with amount</param>
        /// <returns>200,400</returns>
        [HttpPost]
        [Route("{id}/bid")]
        public async Task<IHttpActionResult> PlaceABid([FromUri] string id, [FromBody] BidViewModel vm)
        {
            var bidderName = User.Identity.Name;
            var result = _roomAppService.PlaceABid(bidderName, id, vm.Amount);

            if (result.IsValid)
                return Ok();

            return BadRequest(result.ToModelState());
        }
    }
}