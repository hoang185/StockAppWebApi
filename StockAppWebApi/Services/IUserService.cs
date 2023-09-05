using System;
using StockAppWebApi.Models;


namespace StockAppWebApi.Services
{
    public interface IUserService
    {
        Task<User> CreateAsync(User user);
    }
}
