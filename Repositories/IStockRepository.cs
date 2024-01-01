﻿using StockAppWebApi.Models;

namespace StockAppWebApi.Repositories
{
    public interface IStockRepository
    {
        Task<Stock?> GetById(int stockId);
    }
}
