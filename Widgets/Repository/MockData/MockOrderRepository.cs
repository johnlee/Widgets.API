using System.Collections.Generic;
using System.Linq;

namespace Widgets.Repository.MockData
{
    public class MockOrderRepository : IOrderRepository
    {
        public List<Order> GetAllOrders()
        {
            return MockData.Orders;
        }

        public Order GetOrderById(int id)
        {
            return MockData.Orders.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Order> GetOrdersByUserId(int userId)
        {
            return MockData.Orders.Where(x => x.Buyer.Id == userId).ToList();
        }

        public List<Order> GetOrdersByWidgetId(int widgetId)
        {
            return MockData.Orders.Where(x => x.Widget.Id == widgetId).ToList();
        }

        public bool CreateOrder(Order order)
        {
            int maxId = MockData.Orders.Max(x => x.Id);
            var user = MockData.Users.Where(x => x.Id == order.Buyer.Id).FirstOrDefault();
            var widget = MockData.Widgets.Where(x => x.Id == order.Widget.Id).FirstOrDefault();

            if (user == null || widget == null) { return false; }

            var newOrder = new Order
            {
                Id = maxId + 1,
                Buyer = user,
                Widget = widget,
                Quantity = order.Quantity,
                Total = widget.Price * order.Quantity
            };
            MockData.Orders.Add(newOrder);
            return true;
        }

        public bool UpdateOrder(Order order)
        {
            var updatedOrder = MockData.Orders.Where(x => x.Id == order.Id).FirstOrDefault();
            var user = MockData.Users.Where(x => x.Id == order.Buyer.Id).FirstOrDefault();
            var widget = MockData.Widgets.Where(x => x.Id == order.Widget.Id).FirstOrDefault();

            if (updatedOrder != null && user != null && widget != null)
            {
                updatedOrder.Buyer = user;
                updatedOrder.Widget = widget;
                updatedOrder.Quantity = order.Quantity;
                updatedOrder.Total = widget.Price * order.Quantity;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteOrder(Order order)
        {
            var deletedOrder = MockData.Orders.Where(x => x.Id == order.Id).FirstOrDefault();
            if (deletedOrder != null)
            {
                MockData.Orders.Remove(deletedOrder);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}