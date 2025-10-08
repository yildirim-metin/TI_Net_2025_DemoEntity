using TI_Net_2025_DemoEntity.DAL.Repositories;
using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.BLL.Services;

public class OrderService
{
    private readonly OrderRepository _orderRepository;

    public OrderService(OrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public int CreateOrder(Order order)
    {
        int newId = _orderRepository.Add(order);
        return newId > 0 ? newId : throw new Exception("Failed to create order.");
    }
}