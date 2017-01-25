using System.Collections.Generic;
using System.Linq;

namespace Widgets.Repository.MockData
{
    public class MockWidgetRepository : IWidgetRepository
    {
        public Widget GetWidgetById(int id)
        {
            return MockData.Widgets.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Widget> GetAllWidgets()
        {
            return MockData.Widgets;
        }

        public List<Widget> GetAllWidgetsByCategoryId(int categoryId)
        {
            return MockData.Widgets.Where(x => x.Category.Id == categoryId).ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return MockData.Categories.Where(x => x.Id == categoryId).FirstOrDefault();
        }

        public List<Category> GetAllCategories()
        {
            return MockData.Categories;
        }

        public bool CreateWidget(Widget widget)
        {
            int maxId = MockData.Widgets.Max(x => x.Id);
            var category = MockData.Categories.Where(x => x.Id == widget.Category.Id).FirstOrDefault();

            if (category == null) { return false; }

            var newWidget = new Widget
            {
                Id = maxId + 1,
                Name = widget.Name,
                Category = category,
                Description = widget.Description,
                Price = widget.Price
            };
            MockData.Widgets.Add(widget);
            return true;
        }

        public bool UpdateWidget(Widget widget)
        {
            var updatedWidget = MockData.Widgets.Where(x => x.Id == widget.Id).FirstOrDefault();
            var category = MockData.Categories.Where(x => x.Id == widget.Category.Id).FirstOrDefault();

            if (updatedWidget != null && category != null)
            {
                updatedWidget.Category = category;
                updatedWidget.Name = widget.Name;
                updatedWidget.Description = widget.Description;
                updatedWidget.Price = widget.Price;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteWidget(Widget widget)
        {
            var deletedWidget = MockData.Widgets.Where(x => x.Id == widget.Id).FirstOrDefault();

            if (deletedWidget != null)
            {
                MockData.Widgets.Remove(deletedWidget);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}