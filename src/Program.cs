using System.Text.Json;
using Graph.Interconected.Models;

internal class Program
{
    private static async void Main(string[] args)
    {
        var count = 33;
        var category = default(Category);

        while (count > 0)
        {
            category = CreateCategories();
        }

        var json = JsonSerializer.Serialize(category);

        File.WriteAllText("./json", json);

        var busca = Console.ReadLine();
        var result = await GraphExtensions.FindAsync<Category>(category);
        var jsonResult = JsonSerializer.Serialize(result);

        Console.WriteLine(jsonResult);

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

        Category CreateNode(Category node)
        {
            node = CreateCategories();

            return node;
        }

        void SetNodes(Category category)
        {
            category = CreateNode(category.Bottom);
            category = CreateNode(category.Top);
            category = CreateNode(category.Right);
            category = CreateNode(category.Left);
        }
    }
}