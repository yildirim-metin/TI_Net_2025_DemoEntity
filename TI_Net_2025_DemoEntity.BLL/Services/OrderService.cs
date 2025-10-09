using TI_Net_2025_DemoEntity.DAL.Repositories;
using TI_Net_2025_DemoEntity.DL.Entities;
using TI_Net_2025_DemoEntity.DL.Enums;

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
            int totalQuantity = _stockRepository.GetStockQuantityByProductId(l.ProductId);
            if (totalQuantity >= l.Quantity)
            {
                Stock stock = _stockRepository.GetOnsiteStockByProductId(l.ProductId) ?? new();
                l.Status = stock.CurrentQuantity >= l.Quantity ? OrderLineStatus.Completed : OrderLineStatus.Restocking;

                int oldQuantity = stock.CurrentQuantity;
                if (stock.Id > 0)
                {
                    stock.CurrentQuantity -= l.Quantity;
                    _stockRepository.Update(stock);
                }

                if (l.Status == OrderLineStatus.Restocking)
                {
                    stock = _stockRepository.GetStockWareHouseByProductId(l.ProductId) ?? new();
                    l.Status = stock.CurrentQuantity >= l.Quantity ? OrderLineStatus.Completed : OrderLineStatus.Restocking;
                    if (stock.Id > 0)
                    {
                        stock.CurrentQuantity -= l.Quantity - oldQuantity;
                        _stockRepository.Update(stock);
                    }
                }
            }
        });
        int newId = _orderRepository.Add(order);
        return newId > 0 ? newId : throw new Exception("Failed to create order.");
    }
}