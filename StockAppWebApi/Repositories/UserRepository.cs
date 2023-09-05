using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using Microsoft.EntityFrameworkCore;
using StockAppWebApi.Models;
using StockAppWebApi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DbContext _context;//đối tượng để kết nối cơ sở dữ liệu

    public UserRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<User> GetByEmail(string email)
    {
        return await _context.Set<User>().FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<User> GetById(int id)
    {
        return await _context.Set<User>().FindAsync(id);
    }

    public async Task<User> GetByUsername(string username)
    {
        return await _context.Set<User>().FirstOrDefaultAsync(x => x.Username == username);
    }
    public async Task<int> Create(User user)
    {
        //dùng procedure
        throw new NotImplementedException();
    }
}
