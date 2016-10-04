using System;
using System.Threading.Tasks;
using System.Web.Http;
using Auctionata.Application.Entities;
using Auctionata.Application.Interfaces;

namespace Auctionata.Presentation.WebAPI.Controllers
{
    [Authorize]
    public class ItemController : ApiController
    {
        private readonly IItemAppService _itemAppService;

        public ItemController(IItemAppService itemAppService)
        {
            _itemAppService = itemAppService;
        }

        /// <summary>
        /// Displaying information about the current item
        /// </summary>
        /// <param name="id">Room ID</param>
        /// <returns>name, picture, description, etc</returns>

        [HttpGet]
        public Task<Item> Get(string id)
        {
            var guid = new Guid(id);
            var item = _itemAppService.Get(guid);

            return Task.FromResult(item);
        }
    }
}
