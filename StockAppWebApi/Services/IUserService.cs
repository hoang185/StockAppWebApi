using System;
using StockAppWebApi.Models;
using StockAppWebApi.ViewModels;


namespace StockAppWebApi.Services
{
    public interface IUserService
    {
        Task<User?> CreateAsync(RegisterViewModel registerViewModel);
        Task<User?> GetUserById(int userId);
        Task<string?> Login(LoginViewModel loginViewModel);
    }
}
