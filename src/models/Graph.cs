namespace Graph.Interconected.Models
{
    public class Node<T>(T value) where T : class
    {
        public T Value { get; set; } = value;
        public Connection<T>? Connection { get; set; }
    }

    public class Connection<T>(Node<T> aource) where T : class
    {
        public Node<T> Source { get; set; } = aource;
        public List<Node<T>>? Nodes { get; set; }
    }

    public class Graph<T> where T : class
    {
        public Node<T>? Root { get; set; }
        public List<Connection<T>> Connections { get; set; } = [];
    }
}