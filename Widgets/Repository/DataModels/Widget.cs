namespace Widgets.Repository
{
    public class Widget
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}