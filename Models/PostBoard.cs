namespace tftwebapi.Models
{
    public partial class PostBoard
        {
            public int BoardId { get; set; }

            public int Id { get; set; }

            public string Boardname { get; set; } = null!;

            public virtual PostUser IdNavigation { get; set; } = null!;
        }
}
