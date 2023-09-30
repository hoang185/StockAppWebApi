using System;
using StockAppWebApi.Models;
using StockAppWebApi.ViewModels;


namespace StockAppWebApi.Services
{
    public interface IUserService
    {
        Task<User?> CreateAsync(RegisterViewModel registerViewModel);
        Task<string?> Login(LoginViewModel loginViewModel);
    }
}
