namespace PrescriberPoint.Domain;

public class Prescription : EntityBase
{
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}