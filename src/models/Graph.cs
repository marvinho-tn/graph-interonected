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
            while(true)
            {
                Root.Connecteds.Add(item);

                foreach(var node in Root.Connecteds)
                {
                    
                }

                break;
            }
        }
    }
}