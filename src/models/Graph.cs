namespace Graph.Interconected.Models
{   
    public class Graph<T> where T : class
    {
        public Graph<T>? Right { get; set; }
        public Graph<T>? Left { get; set; }
        public Graph<T>? Top { get; set; }
        public Graph<T>? Bottom { get; set; }
    }
}