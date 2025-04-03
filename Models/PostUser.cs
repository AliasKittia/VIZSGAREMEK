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

            public string Password { get; set; } = null!; // Add this field for plain-text password input

            public virtual ICollection<PostBoard> Boards { get; set; } = new List<PostBoard>();

            public virtual PostPermission Permission { get; set; } = null!;
    }
}