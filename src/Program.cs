using System.Text.Json;
using Graph.Interconected.Models;

internal class Program
{
    private static async void Main(string[] args)
    {
        var count = 33;
        var category = default(Category);
        var list = new List<Category>();

        while (count > 0)
        {
            category = CreateCategories();

            list.Add(category);
        }

        var json = JsonSerializer.Serialize(category);

        File.WriteAllText("./json", json);

        string CreateId()
        {
            return Guid.NewGuid().ToString();
        }

        Category CreateCategories(Category? category = null)
        {
            category ??= new Category(CreateId());

            SetNodes(category);

            return category;
        }

        void SetNodes(Category category)
        {
            CreateCategories(category.Bottom);
            CreateCategories(category.Top);
            CreateCategories(category.Right);
            CreateCategories(category.Left);
        }
    }
}