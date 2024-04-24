using System.Linq.Expressions;
using Microsoft.VisualBasic;

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
                node = FindGraphAsync(source, node, cancellationToken).Result;

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

            var bottom = FindGraphAsync(graph, graph.Bottom, cancellationToken);
            var top = FindGraphAsync(graph, graph.Top, cancellationToken);
            var left = FindGraphAsync(graph, graph.Left, cancellationToken);
            var right = FindGraphAsync(graph, graph.Right, cancellationToken);

            var tasks = Task.WhenAny(bottom, top, left, right);

            return tasks.Result;
        }

        // public static Task<T?> FindAsync<T>(this T? graph, Expression<Func<Task<T>>> expression, CancellationTokenSource? cancellationToken = null) where T : Graph<T>
        // {
        //     cancellationToken ??= new CancellationTokenSource();

        //     return FindAsync<Task<T>>(expression(graph), cancellationToken);
        // }
    }
}