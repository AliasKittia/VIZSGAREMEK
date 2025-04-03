using System.Text.Json.Serialization;

namespace tftwebapinew.Models{
    public class PostUser{
            public int Id { get; set; }

            public required string LoginName { get; set; }

            public required string Hash { get; set; }

            public required string Salt { get; set; }

            public required string Name { get; set; }

            public int PermissionId { get; set; }

            public bool Active { get; set; }

            public required string Email { get; set; }

            public required string  ProfilePicturePath { get; set; }
            [JsonIgnore]
            public virtual ICollection<PostBoard> Boards { get; set; } = new List<PostBoard>();
            [JsonIgnore]
            public virtual PostPermission Permission { get; set; } = null!;
    }
}