using System.Text.Json;
using Graph.Interconected.Models;

internal class Program
{
    private static void Main(string[] args)
    { 
        var category1 = new Category("1");
        var category2 = new Category("2");
        var category3 = new Category("3");
        var node1 = new Node<Category>(category1);
        var node2 = new Node<Category>(category2);
        var node3 = new Node<Category>(category3);
        
        node1.Connection = new Connection<Category>(node2);
        node1.Connection.Connect = new Connection<Category>(node3);

        var graph = new Graph<Category>();

        graph.Roots.Add(node1);
        graph.Roots.Add(node2);
        graph.Roots.Add(node3);

        var json = JsonSerializer.Serialize(graph);

        Console.WriteLine(json);
    }
}