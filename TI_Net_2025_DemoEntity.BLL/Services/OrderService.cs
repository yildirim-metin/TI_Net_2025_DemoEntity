using TI_Net_2025_DemoEntity.DAL.Repositories;
using TI_Net_2025_DemoEntity.DL;
using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.BLL.Services;

public class OrderService
{
    private readonly OrderRepository _orderRepository;
    private readonly StockRepository _stockRepository;

    public OrderService(OrderRepository orderRepository, StockRepository stockRepository)
    {
        _orderRepository = orderRepository;
        _stockRepository = stockRepository;
    }

    public IEnumerable<Order> GetOrders()
    {
        return _orderRepository.GetAll();
    }

    public int CreateOrder(Order order)
    {
        order.Lines.ForEach(l =>
        {
            int quantity = _stockRepository.GetStockByProductId(l.ProductId);
            l.Status = quantity > l.Quantity ? OrderLineStatus.Completed : OrderLineStatus.Restocking;
        });
        int newId = _orderRepository.Add(order);
        return newId > 0 ? newId : throw new Exception("Failed to create order.");
    }
}