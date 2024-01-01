using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StockAppWebApi.ViewModels
{
    public class RegisterViewModel
    {
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";
        [Required]
        public string Phone { get; set; } = "";
        public string? FullName { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Country { get; set; }
    }
}
