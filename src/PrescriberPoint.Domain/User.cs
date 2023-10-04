namespace PrescriberPoint.Domain
{
    public class User : EntityBase
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}