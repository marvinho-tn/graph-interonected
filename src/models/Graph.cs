namespace Graph.Interconected.Models
{
    public class Node<T> where T : class
    {
        public Node<T>? Right { get; set; }
        public Node<T>? Left { get; set; }
        public Node<T>? Top { get; set; }
        public Node<T>? Bottom { get; set; }
    }

    public class Graph<T> where T : class
    {
        public Node<T>? Root { get; set; }

        private void Add(Node<T> item)
        { 
            if(Root is null)
                Root = item;
            else if(Root.Top is null)
                Root.Top = item;
            else if(Root.Right is null)
                Root.Right = item;
            else if(Root.Bottom is null)
                Root.Bottom = item;
            else if(Root.Left is null)
                Root.Left = item;

            
        }
    }
}