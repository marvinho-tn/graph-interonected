namespace Graph.Interconected.Models
{
    public interface IGraph<T> where T : class
    {
        public T? Right { get; set; }
        public T? Left { get; set; }
        public T? Top { get; set; }
        public T? Bottom { get; set; }
    }
    
    public class Graph<T> : IGraph<T> where T : class
    {
        public T? Right { get; set; }
        public T? Left { get; set; }
        public T? Top { get; set; }
        public T? Bottom { get; set; }

        private static Task<T?> FindGraphAsync(T source, T? node)
        {
            var cancellationToken = new CancellationTokenSource();
            var tokenSource = cancellationToken.Token;

            if (node == null)
            {
                cancellationToken.Cancel();

                return Task.FromCanceled<T?>(tokenSource);
            }

            if (node == source)
                return Task.FromResult<T?>(node);

            while (node != source)
                node = FindAsync(node, tokenSource).Result;

            return Task.FromResult<T?>(node);
        }

        public static Task<T?> FindAsync(T? graph, CancellationToken tokenSource)
        {
            if (graph == null)
            {
                return Task.FromCanceled<T?>(tokenSource);
            }

            var bottom = FindGraphAsync(graph, graph.Bottom);
            var top = FindGraphAsync(graph, graph.Top);
            var left = FindGraphAsync(graph, graph.Left);
            var right = FindGraphAsync(graph, graph.Right);

            var tasks = Task.WhenAny(bottom, top, left, right);

            return tasks.Result;
        }
    }
}