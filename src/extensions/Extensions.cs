namespace Graph.Interconected.Models
{
    public static class GraphExtensions
    {
        private static Task<T?> FindGraphAsync<T>(T source, T? node, CancellationTokenSource? cancellationToken = null) where T : Graph<T>
        {
            cancellationToken ??= new CancellationTokenSource();

            var tokenSource = cancellationToken.Token;

            if (node == null)
            {
                cancellationToken.Cancel();

                return Task.FromCanceled<T?>(tokenSource);
            }

            if (node == source)
                return Task.FromResult<T?>(node);

            while (node != source)
                node = FindGraphAsync(source, node).Result;

            return Task.FromResult<T?>(node);
        }

        public static Task<T?> FindAsync<T>(this T? graph, CancellationTokenSource? cancellationToken = null) where T : Graph<T>
        {
            cancellationToken ??= new CancellationTokenSource();

            var tokenSource = cancellationToken.Token;

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