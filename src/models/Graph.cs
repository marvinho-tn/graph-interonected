namespace Graph.Interconected.Models
{
    public class Node<T>(T value) where T : class
    {
        public T Value { get; set; } = value;
        public List<Node<T>> Connecteds { get; set; } = [];
    }

    public class Graph<T>(Node<T> root) where T : class
    {
        private Node<T> Root { get; set; } = root;

        public void Add(Node<T> item)
        {
            Root.Connecteds.ForEach(node => node.Connecteds.Add(item));
        }
    }
}