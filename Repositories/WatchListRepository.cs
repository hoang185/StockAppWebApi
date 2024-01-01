
using Microsoft.EntityFrameworkCore;
using StockAppWebApi.Models;

namespace StockAppWebApi.Repositories
{
    public class WatchListRepository : IWatchListRepository
    {
        private readonly StockAppContext _context;
        public WatchListRepository(StockAppContext context)
        {
            _context = context;
        }
        public async Task AddStockToWatchList(int userId, int stockId)
        {
            var watchList = await _context.WatchLists.FindAsync(userId, stockId);

            if (watchList == null)
            {
                watchList = new WatchList 
                { 
                    StockId = stockId ,
                    UserId = userId
                };

                _context.WatchLists.Add(watchList);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<WatchList?> GetById(int userId, int stockId)
        {
            return await _context.WatchLists.FirstOrDefaultAsync(x => x.StockId == stockId && x.UserId == userId); 
        }
    }
}
