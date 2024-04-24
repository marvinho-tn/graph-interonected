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
            foreach (var root in Root.Connecteds)
            {
                AddNode(root, item);
            }
        }

        private void AddNode(Node<T> root, Node<T> item)
        {
            foreach (var r in root.Connecteds)
            {
                r.Connecteds.Add(item);

                AddNode(r, item);
            }            
        }
    }
}