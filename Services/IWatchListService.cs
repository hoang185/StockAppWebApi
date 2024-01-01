using System;
using StockAppWebApi.Models;
using StockAppWebApi.Services;

namespace StockAppWebApi.Services
{
    public interface IWatchListService
    {
        public Task AddStockToWatchlist(int userId, int stockId);
        Task<WatchList?> GetWatchList(int userId, int stockId);
    }
}
