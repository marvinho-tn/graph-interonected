namespace Graph.Interconected.Models
{
    public interface IGraph<T> where T : class
    {
        T? Right { get; set; }
        T? Left { get; set; }
        T? Top { get; set; }
        T? Bottom { get; set; }

        void Add(T item);
    }

    public class Graph<T> : IGraph<T> where T : Graph<T>
    {
        public T? Right { get; set; }
        public T? Left { get; set; }
        public T? Top { get; set; }
        public T? Bottom { get; set; }

        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var added = false;

            while(added)
            {
                
            }
        }
    }
}