using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockAppWebApi.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "The username is required.")]
        [MinLength(3,ErrorMessage = "Min length is 3 characters")]
        [MaxLength(100)]
        [Column("username")]
        public required string Username
        {
            get;
            set;
        }
        [Column("hashed_password")]
        public required string HashedPassword { get; set; }

        [Required]
        [EmailAddress]
        [Column("email")]
        public required string Email { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(20)]
        [Column("phone")]
        public required string Phone { get; set; }
        [Column("full_name")]
        public required string FullName { get; set; }
        [Column("date_of_birth")]
        public DateTime? DateOfBirth { get; set; }
        [Column("country")]
        public required string Country { get; set; }

        public ICollection<WatchList>? WatchLists { get; set; }
    }

}
