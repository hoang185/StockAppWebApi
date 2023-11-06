using Microsoft.EntityFrameworkCore;
using System;

namespace StockAppWebApi.Models
{
    public class StockAppContext : DbContext
    {
        public StockAppContext(DbContextOptions<StockAppContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)// định nghĩa cấu trúc cơ sở dữ liệu bằng cách sử dụng modelBuilder
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WatchList>()
                .HasKey(w => new { w.StockId, w.UserId });//khóa chính của bảng WatchList sẽ bao gồm cả trường StockId và UserId
        }
    }
}
