using System.Net.Http;
using System.Web.Http.Routing;
using Widgets.Repository;

namespace Widgets.Models
{
    public class ModelFactory
    {
        IRepository _repository;
        UrlHelper _url;

        public ModelFactory(IRepository repository, HttpRequestMessage request)
        {
            _repository = repository;
            _url = new UrlHelper(request); // UrlHelper to get route information
        }

        #region ViewModels

        public Product Create(Widget widget)
        {
            Widget wdgt = _repository.Widgets.GetWidgetById(widget.Id);
            if (wdgt != null)
            {
                var product = new Product();
                product.Id = widget.Id;
                product.Name = widget.Name;
                product.Description = widget.Description;
                product.Price = widget.Price;
                product.Type = Create(widget.Category);
                product.Url = _url.Link("DefaultApi", new { controller = "Products", id = product.Id });
                return product;
            }
            else
            {
                // TODO Error Handling
                return new Product();
            }
        }

        public ProductType Create(Category category)
        {
            Category cat = _repository.Widgets.GetCategoryById(category.Id);
            if (cat != null)
            {
                var productType = new ProductType();
                productType.Id = cat.Id;
                productType.Description = cat.Name;
                return productType;
            }
            else
            {
                // TODO Error Handling
                return new ProductType();
            }
        }

        public PurchaseOrder Create(Order order)
        {
            Order ordr = _repository.Orders.GetOrderById(order.Id);
            if (ordr != null)
            {
                var purchaseOrder = new PurchaseOrder();
                purchaseOrder.Id = order.Id;
                purchaseOrder.ProductId = order.Widget.Id;
                purchaseOrder.UserId = order.Buyer.Id;
                purchaseOrder.Quantity = order.Quantity;
                purchaseOrder.TotalPrice = order.Total;
                purchaseOrder.Url = _url.Link("DefaultApi", new { controller = "Orders", id = order.Id });
                return purchaseOrder;
            }
            else
            {
                // TODO Error Handling
                return new PurchaseOrder();
            }
        }

        #endregion

        #region DataModels

        public Widget Create(Product product)
        {
            var category = _repository.Widgets.GetCategoryById(product.Type.Id);
            Widget widget = new Widget();
            widget.Id = product.Id;
            widget.Name = product.Name;
            widget.Description = product.Description;
            widget.Category = category;
            widget.Price = product.Price;
            return widget;
        }

        public Category Create(ProductType productType)
        {
            Category category = new Category();
            category.Id = productType.Id;
            category.Name = productType.Description;
            return category;
        }

        public Order Create(PurchaseOrder purchaseOrder)
        {
            Order order = new Order();
            Widget widget = _repository.Widgets.GetWidgetById(purchaseOrder.ProductId);
            User user = new User // TODO User information should come from environment. We just make fake for now.
            {
                Id = purchaseOrder.UserId,
                Firstname = "FirstName",
                Lastname = "LastName",
                Email = "user@email.com"
            };

            order.Id = purchaseOrder.Id;
            order.Buyer = user;
            order.Widget = widget;
            order.Quantity = purchaseOrder.Quantity;
            order.Total = purchaseOrder.TotalPrice;
            return order;
        }

        #endregion
    }
}