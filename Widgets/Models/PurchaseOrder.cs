namespace Widgets.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}