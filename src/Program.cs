using Graph.Interconected.Models;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            CreateCategories();
        }

        private static string CreateId()
        {
            return Guid.NewGuid().ToString();
        }

        private static Category CreateCategories()
        {
            var category = new Category(CreateId());

            SetNodes(category);

            return category;
        }

        private static Category CreateNode(Category node)
        {
            node = CreateCategories();

            return node;
        }

        private static void SetNodes(Category category)
        {
            category = CreateNode(category.Bottom);
            category = CreateNode(category.Top);
            category = CreateNode(category.Right);
            category = CreateNode(category.Left);
        }
    }
}