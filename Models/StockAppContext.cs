using Microsoft.EntityFrameworkCore;
using System;

namespace StockAppWebApi.Models
{
    //mỗi model tương ứng với một bảng hoặc view và cần phải khai báo trong context
    public class StockAppContext : DbContext
    {
        public StockAppContext(DbContextOptions<StockAppContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<RealtimeQuote> RealtimeQuotes  { get; set; }
        public DbSet<Quote> Quotes  { get; set; }
        public DbSet<Order> Orders  { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)// định nghĩa cấu trúc cơ sở dữ liệu bằng cách sử dụng modelBuilder
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WatchList>()
                .HasKey(w => new { w.StockId, w.UserId });//khóa chính của bảng WatchList sẽ bao gồm cả trường StockId và UserId
            modelBuilder.Entity<Order>().ToTable(table => table.HasTrigger("trigger_orders"));
        }
    }
}
