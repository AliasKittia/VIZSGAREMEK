using System.Text.Json.Serialization;

namespace tftwebapinew.Models{
    public class PostUser{
            public int Id { get; set; }

            public string LoginName { get; set; } = null!;

            public string Hash { get; set; } = null!;

            public string Salt { get; set; } = null!;

            public string Name { get; set; } = null!;

            public int PermissionId { get; set; }

            public bool Active { get; set; }

            public string Email { get; set; } = null!;

            public string ProfilePicturePath { get; set; } = null!;
            [JsonIgnore]
            public virtual ICollection<PostBoard> Boards { get; set; } = new List<PostBoard>();
            [JsonIgnore]
            public virtual PostPermission Permission { get; set; } = null!;
    }
}