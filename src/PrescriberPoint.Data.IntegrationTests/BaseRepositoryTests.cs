namespace PrescriberPoint.Data.IntegrationTests;

public class BaseRepositoryTests
{
    protected string ConnectionString { get; } = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PrescriberPoint;User ID=prescriberpoint;Password=prescriberpoint;Connect Timeout=60;Encrypt=False;";
}