using Microsoft.AspNetCore.Mvc;
using TI_Net_2025_DemoEntity.API.Mappers;
using TI_Net_2025_DemoEntity.API.Models.Orders;
using TI_Net_2025_DemoEntity.BLL.Services;

namespace TI_Net_2025_DemoEntity.API.Controllers;

[ApiController]
[Route("api/Order")]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPut]
    public ActionResult CreateOrder([FromBody] OrderDto orderDto)
    {
        try
        {
            _orderService.CreateOrder(orderDto.ToOrder());
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}