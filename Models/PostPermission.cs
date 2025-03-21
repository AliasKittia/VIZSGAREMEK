
namespace tftwebapi.Models{
    public partial class PostPermission
{
    public int Id { get; set; }

    public int Level { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<PostUser> Users { get; set; } = new List<PostUser>();
}

}

