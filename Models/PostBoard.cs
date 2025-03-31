namespace tftwebapinew.Models
{
    public class PostBoard
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int PostUserId { get; set; } // Foreign key for PostUser

        public virtual PostUser PostUser { get; set; } = null!; // Navigation property
    }
}