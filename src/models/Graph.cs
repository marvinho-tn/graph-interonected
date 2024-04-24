namespace Graph.Interconected.Models
{
    public interface IGraph<T> where T : class
    {
        public T? Right { get; set; }
        public T? Left { get; set; }
        public T? Top { get; set; }
        public T? Bottom { get; set; }
    }
    
    public class Graph<T> : IGraph<T> where T : Graph<T>
    {
        public T? Right { get; set; }
        public T? Left { get; set; }
        public T? Top { get; set; }
        public T? Bottom { get; set; }
    }
}