using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StockAppWebApi.Attributes;
using StockAppWebApi.Models;
using StockAppWebApi.Repositories;
using StockAppWebApi.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var settings = builder.Configuration.GetRequiredSection("ConnectionStrings");//read data from appsettings.json
builder.Services.AddDbContext<StockAppContext>(options => options.UseSqlServer(settings["DefaultConnection"]));

//addtransisent: một instance mới được tạo mỗi lần yêu cầu sử dụng
//addscoped: được tạo cho mỗi lần yêu cầu HTTP
//addsingleton: một instance được tạo duy nhất cho toàn ứng dụng
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();    
builder.Services.AddScoped<IWatchListRepository, WatchListRepository>();    
builder.Services.AddScoped<IWatchListService, WatchListService>();    
builder.Services.AddScoped<IStockRepository, StockRepository>();    
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IQuoteRepository, QuoteRepository>();
builder.Services.AddScoped<IQuoteService, QuoteService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<JwtAuthorizeAttribute>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
});
//    .AddJwtBearer(options => 
//{
//    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = "your_issuer",
//        ValidAudience = "your_audience",
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key")),
//    };
//});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

var webSocketOptions = new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromMinutes(2),//moi 2 phut se gui 1 thong bao keep-alive toi may chu de dam bao ket noi websocket ko bi dong
};
app.UseWebSockets(webSocketOptions);//dki su dung websocket
app.Run();
