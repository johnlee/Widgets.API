namespace Widgets.Repository
{
    public interface IRepository
    {
        IWidgetRepository Widgets { get; }
        IOrderRepository Orders { get; }
    }
}
