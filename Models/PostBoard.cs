namespace tftwebapinew.Models
{
    public class PostBoard
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int PostUserId { get; set; } 

        public virtual PostUser PostUser { get; set; } = null!;
    }
}