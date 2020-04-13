namespace Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public int? ParentId { get; set; }
        public Category Parent { get; set; } = null;

        public Product Product { get; set; }
    }
}
