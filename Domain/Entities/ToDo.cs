namespace Domain.Entities
{
    public class ToDo
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
