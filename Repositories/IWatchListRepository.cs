using StockAppWebApi.Models;

namespace StockAppWebApi.Repositories
{
    public interface IWatchListRepository
    {
        Task AddStockToWatchList(int userId, int stockId);
        Task<WatchList?> GetById(int userId, int stockId);
    }
}
