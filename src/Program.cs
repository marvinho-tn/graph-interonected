using System.Text.Json;
using GraphProject.Models;

namespace GraphProject
{
    public class Program
    {
        public Program(params string[] args)
        {
            var graphone = new Graph();
            var graphtwo = new Graph();
            var graphthree = new Graph();
            var graphfour = new Graph();

            graphone.Chield = graphtwo;
            graphone.Left = graphthree;
            graphone.Parent = graphfour;
            graphone.Right = graphone;

            var four2 = Graph.Search(graphtwo);
            var four3 = Graph.Search(graphthree);
            var four4 = Graph.Search(graphfour);

            Console.WriteLine(JsonSerializer.Serialize(new {
                four2,
                four3,
                four4
            }));
        }
    }

}