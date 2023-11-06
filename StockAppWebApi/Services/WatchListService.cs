using System;
using StockAppWebApi.Models;
using StockAppWebApi.Repositories;

namespace StockAppWebApi.Services
{
    public class WatchListService : IWatchListService
    {
        private readonly IWatchListRepository _repository;
        public WatchListService(IWatchListRepository repository)
        {
            _repository = repository;
        }
        public async Task AddStockToWatchlist(int userId, int stockId)
        {
            await _repository.AddStockToWatchList(userId, stockId);
        }
        public async Task<WatchList?> GetWatchList(int userId, int stockId)
        {
            return await _repository.GetById(userId, stockId);
        }
    }
}
