using System.Text.Json;
using Graph.Interconected.Models;

internal class Program
{
    private static async void Main(string[] args)
    {
        var count = 10;
        var root = new Node<Category>(new Category(Guid.NewGuid().ToString()));
        var graph = new Graph<Category>(root);

        while (count > 0)
        {
            var node = new Node<Category>(new Category(Guid.NewGuid().ToString()));
            graph.Add(node);
        }

        var json = JsonSerializer.Serialize(graph);

        Console.WriteLine(json);    
    }
}