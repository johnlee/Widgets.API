namespace Widgets.Repository
{
    public class Order
    {
        public int Id { get; set; }
        public User Buyer { get; set; }
        public Widget Widget { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}