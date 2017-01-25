using System.Collections.Generic;

namespace Widgets.Repository
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        List<Order> GetOrdersByUserId(int userId);
        List<Order> GetOrdersByWidgetId(int widgetId);
        bool CreateOrder(Order order);
        bool UpdateOrder(Order order);
        bool DeleteOrder(Order order);
    }
}
