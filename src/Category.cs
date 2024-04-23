namespace GraphProject.Models
{
    public class Category : Graph
    {
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string? Description { get; set; }
        public Category? Parent { get; set; }
    }
} 