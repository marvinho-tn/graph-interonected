namespace Graph.Interconected.Models
{
    public class Category(string name) : Graph
    {
        public string Name { get; set; } = name;
        public string? Value { get; set; }
        public string? Description { get; set; }
        public string? Signification { get; set; }
        public Category? Parent { get; set; }
        public Category? Chield { get; set; }
    }
} 