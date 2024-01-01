using Microsoft.AspNetCore.Mvc;
using StockAppWebApi.Services;
using System.Text;
using System.Net.WebSockets;
using StockAppWebApi.Models;
using System.Text.Json;

namespace StockAppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _quoteService;
        public QuoteController(IQuoteService quoteService)
        {
                _quoteService = quoteService;
        }
        [HttpGet("ws")]
        //https://localhost:7294/api/quote/ws
        public async Task GetRealtimeQuotes(int page = 1, int limit = 10, string sector = "", string industry = "")
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                while (webSocket.State == WebSocketState.Open && page <= 5)
                {
                    List<RealtimeQuote>? quotes = await _quoteService.GetRealtimeQuotes(page, limit, sector, industry);
                    string jsonString = JsonSerializer.Serialize(quotes);
                    var buffer = Encoding.UTF8.GetBytes(jsonString);
                    await webSocket.SendAsync(
                        new ArraySegment<byte>(buffer),
                        System.Net.WebSockets.WebSocketMessageType.Text, true, CancellationToken.None);
                    await Task.Delay(2000);//doi 2 giay truoc gui gia tri tiep theo
                    page++;

                }
                await webSocket.CloseAsync(System.Net.WebSockets.WebSocketCloseStatus.NormalClosure, "Connection closed by the server", CancellationToken.None);
            }
        }

        [HttpGet("historical")]
        public async Task<IActionResult> GetHistoricalQuotes(int days, int stockId)
        {
            var historicalQuotes = await _quoteService.GetHistoricalQuotes(days, stockId);
            return Ok(historicalQuotes);
        }
    }
}
