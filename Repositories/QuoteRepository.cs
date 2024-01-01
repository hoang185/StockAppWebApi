using Microsoft.EntityFrameworkCore;
using StockAppWebApi.Models;

namespace StockAppWebApi.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly StockAppContext _context;
        public QuoteRepository(StockAppContext context)
        {
            _context = context;
        }

        public async Task<List<Quote>> GetHistoricalQuotes(int days, int stockId)
        {
            var today = new DateTime(2023, 4, 30);
            var fromDate = today.Date.AddDays(-days);
            var toDate = today.Date;
            var historicalQuotes = await _context.Quotes.Where(q => q.TimeStamp >= fromDate && q.TimeStamp <= toDate && q.StockId == stockId)
                .GroupBy(q => q.TimeStamp.Date)//nhóm các giá trị trong cùng 1 ngày
                .Select(g => new Quote
                {
                    TimeStamp = g.Key,
                    Price = g.Average(q => q.Price),//lấy giá trị trung bình cộng trong 1 ngày
                })
                .OrderBy(q => q.TimeStamp).ToListAsync();

            return historicalQuotes;
        }

        public async Task<List<RealtimeQuote>?> GetRealtimeQuotes(int page, int limit, string sector, string industry)
        {
            var query = _context.RealtimeQuotes.Skip((page - 1) * limit).Take(limit);
            if (!string.IsNullOrEmpty(sector))
            {
                query = query.Where(x => (x.Sector ?? "").ToLower() == sector.ToLower());
            }
            if (!string.IsNullOrEmpty(industry))
            {
                query = query.Where(x => (x.Industry ?? "").ToLower() == industry.ToLower());
            }
            var quotes = await query.ToListAsync();
            return quotes;
        }
    }
}
