namespace tftwebapinew.DTO{
     public class LoggedUser
    {
        public required string Name { get; set; }

        public required string Email { get; set; }

        public int? Permission { get; set; }

        public required string ProfilePicturePath { get; set; }

        public required string Token { get; set; }
    }
}