namespace tftwebapi.DTO
{
    public class LoginDTO
    {
        public required string LoginName { get; set; }

        public required string TmpHash { get; set; }
    }
}
