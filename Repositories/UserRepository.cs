using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StockAppWebApi.Models;
using StockAppWebApi.ViewModels;
using System.Security.Claims;

namespace StockAppWebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StockAppContext _context;//đối tượng để kết nối cơ sở dữ liệu
        private readonly IConfiguration _configuration;

        public UserRepository(StockAppContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        }
        public async Task<string> Login(LoginViewModel loginViewModel)
        {
            //dùng procedure
            string sql = "execute dbo.CheckLogin @email, @password";

            var lstUsers = await _context.Users.ToListAsync();
            IEnumerable<User> result = await _context.Users.FromSqlRaw(sql,
                new SqlParameter("@email", loginViewModel.Email),
                new SqlParameter("@password", loginViewModel.Password)).ToListAsync();
            User? user = result.FirstOrDefault();
            if (user != null)
            {
                //tạo chuỗi jwt để gửi đến client
                var tokenHandler = new JwtSecurityTokenHandler();

                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"] ?? "");//secret key dùng để mã hóa và trong thành phần signature của token
                                                                                         //var jwt = _configuration.GetRequiredSection("Jwt");
                                                                                         //var jwt2 = jwt["SecretKey"];
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),//thuộc tính được đưa vào token, có thể được thuộc tính khác và bất kỳ
                    }),

                    Expires = DateTime.UtcNow.AddDays(30),//hạn sử dụng của token
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),//secret key và thuật toán dùng để mã hóa
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                return jwtToken;
            }
            else
            {
                throw new Exception("wrong email or password");
            }
        }
        public async Task<User?> Create(RegisterViewModel registerViewModel)
        {
            //dùng procedure
            string sql = "execute dbo.RegisterUser @username, @password, @email, @phone, @full_name, @date_of_birth, @country";
            IEnumerable<User> result = await _context.Users.FromSqlRaw(sql,
                new SqlParameter("@username", registerViewModel.Username ?? ""),
                new SqlParameter("@password", registerViewModel.Password),
                new SqlParameter("@email", registerViewModel.Email),
                new SqlParameter("@phone", registerViewModel.Phone ?? ""),
                new SqlParameter("@full_name", registerViewModel.FullName ?? ""),
                new SqlParameter("@date_of_birth", registerViewModel.DateOfBirth),
                new SqlParameter("@country", registerViewModel.Country)).ToListAsync();
            User? user = result.FirstOrDefault();
            return user;
        }
    }
}