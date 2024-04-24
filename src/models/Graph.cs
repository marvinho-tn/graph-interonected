namespace Graph.Interconected.Models
{
    public class RootNode<T> where T : class
    {
        public Node<T>? Root { get; set; }
    }

    public class Node<T> where T : class
    {
        Node<T>? Right { get; set; }
        Node<T>? Left { get; set; }
        Node<T>? Top { get; set; }
        Node<T>? Bottom { get; set; }
    }

    public class Graph<T> : RootNode<T> where T : class
    {
        private void Add(Node<T> item)
        { 
            if(Root == null)
                Root = item;
        }
    }
}