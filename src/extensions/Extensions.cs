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

            return Task.FromResult<T?>(node);
        }
    }
}
