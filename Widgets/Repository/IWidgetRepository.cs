using System.Collections.Generic;

namespace Widgets.Repository
{
    public interface IWidgetRepository
    {
        Widget GetWidgetById(int id);
        List<Widget> GetAllWidgets();
        List<Widget> GetAllWidgetsByCategoryId(int categoryId);
        Category GetCategoryById(int categoryId);
        List<Category> GetAllCategories();
        bool CreateWidget(Widget widget);
        bool UpdateWidget(Widget widget);
        bool DeleteWidget(Widget widget);
    }
}
