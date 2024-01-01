using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StockAppWebApi.Services;
using StockAppWebApi.Filters;
using System.Security.Claims;
using StockAppWebApi.Repositories;
using StockAppWebApi.Attributes;
using StockAppWebApi.Extensions;

namespace StockAppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WatchListController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IStockService _stockService;
        private readonly IWatchListService _watchlistService;

        public WatchListController(IUserService userService, IStockService stockService, IWatchListService watchlistService)
        {
            _userService = userService;
            _stockService = stockService;
            _watchlistService = watchlistService;
        }

        [HttpPost("AddStockToWatchlist/{stockId}")]
        [JwtAuthorize]
        public async Task<IActionResult> AddStockToWatchlist(int stockId)
        {
            int userId = HttpContext.GetUserId();
           
            var user = await _userService.GetUserById(userId);
            var stock = await _stockService.GetStockById(stockId);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            if (stock == null)
            {
                return NotFound("Stock not found");
            }

            var existingWatchlistItem = await _watchlistService.GetWatchList(userId, stockId);
            if (existingWatchlistItem != null)
            {
                return BadRequest("Stock has been in watchlist already");
            }

            await _watchlistService.AddStockToWatchlist(userId, stockId);
            return Ok();
        }
    }
}
