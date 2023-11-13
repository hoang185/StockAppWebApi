using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockAppWebApi.Models
{
    [Table("stocks")]
    public class Stock
    {
        [Key]
        [Column("stock_id")]
        public int StockId { get; set; }

        [Required(ErrorMessage = "Mã cổ phiếu không được để trống")]
        [Column("symbol")]
        [StringLength(10, ErrorMessage = "Mã cổ phiếu không được quá 10 ký tự")]
        public string? Symbol { get; set; }

        [Required(ErrorMessage = "Tên công ty không được để trống")]
        [Column("company_name")]
        [StringLength(255, ErrorMessage = "Tên công ty không được quá 255 ký tự")]
        public string? CompanyName { get; set; }

        [Column("market_cap")]
        [Range(0, double.MaxValue, ErrorMessage = "Vốn hóa thị trường phải là số dương")]
        public decimal? MarketCap { get; set; }

        [Column("sector")]
        [StringLength(200, ErrorMessage = "Ngành không được quá 200 ký tự")]
        public string? Sector { get; set; }

        [Column("industry")]
        [StringLength(200, ErrorMessage = "Lĩnh vực không được quá 200 ký tự")]
        public string? Industry { get; set; }

        [Column("sector_en")]
        [StringLength(200, ErrorMessage = "Ngành tiếng Anh không được quá 200 ký tự")]
        public string? SectorEn { get; set; }

        [Column("industry_en")]
        [StringLength(200, ErrorMessage = "Lĩnh vực tiếng Anh không được quá 200 ký tự")]
        public string? IndustryEn { get; set; }

        [Column("stock_type")]
        [StringLength(50, ErrorMessage = "Loại cổ phiếu không được quá 50 ký tự")]
        public string? StockType { get; set; }

        //Common Stock (Cổ phiếu thường),Preferred Stock (Cổ phiếu ưu đãi),ETF (Quỹ Đầu Tư Chứng Khoán)

        [Column("rank")]
        [Range(0, int.MaxValue, ErrorMessage = "Thứ hạng phải là số nguyên dương")]
        public int Rank { get; set; }

        [Column("rank_source")]
        [StringLength(200, ErrorMessage = "Nguồn thứ hạng không được quá 200 ký tự")]
        public string? RankSource { get; set; }

        [Column("reason")]
        [StringLength(255, ErrorMessage = "Nguyên nhân không được quá 255 ký tự")]
        public string? Reason { get; set; }

        public ICollection<WatchList>? WatchLists { get; set; }
    }
}
