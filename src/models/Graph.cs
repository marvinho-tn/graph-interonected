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

            while (added)
            {
                if (Top == null)
                {
                    Top = item;
                    added = true;
                }
                else if (Right == null)
                {
                    Right = item;
                    added = true;
                }
                else if (Bottom == null)
                {
                    Bottom = item;
                    added = true;
                }
                else if (Left == null)
                {
                    Left = item;
                    added = true;
                }
                else
                {
                    Add(item, Top, ref added);
                }
            }
        }

        private void Add(T item, T sub, ref bool added)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            while (added)
            {
                if (Top == null)
                {
                    Top = item;
                    added = true;
                }
                else if (Right == null)
                {
                    Right = item;
                    added = true;
                }
                else if (Bottom == null)
                {
                    Bottom = item;
                    added = true;
                }
                else if (Left == null)
                {
                    Left = item;
                    added = true;
                }
                else
                {
                    Add(item, Top, ref added);
                }
            }
        }
    }
}