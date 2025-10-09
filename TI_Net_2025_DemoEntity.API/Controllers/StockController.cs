using Microsoft.AspNetCore.Mvc;
using TI_Net_2025_DemoEntity.API.Mappers;
using TI_Net_2025_DemoEntity.API.Models.Stocks;
using TI_Net_2025_DemoEntity.BLL.Services;

namespace TI_Net_2025_DemoEntity.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly StockService _stockService;

    public StockController(StockService stockService)
    {
        _stockService = stockService;
    }

    [HttpPost]
    public void CreateStock([FromBody] StockDto stockDto)
    {
        _stockService.CreateStock(stockDto.ToStock());
    }
}
