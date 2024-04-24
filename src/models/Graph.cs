namespace Graph.Interconected.Models
{
    public class Node<T>(T value) where T : class
    {
        public T Value { get; set; } = value;
        public List<Node<T>> Connecteds { get; set; } = [];
    }

    public class Graph<T> where T : class
    {
        private Node<T> Root { get; set; }

        public void Add(Node<T> item)
        {
            Root.Connecteds.Add(item);
        }
    }
}