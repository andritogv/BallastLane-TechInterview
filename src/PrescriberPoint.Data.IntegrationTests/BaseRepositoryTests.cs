using Microsoft.Extensions.Options;

namespace PrescriberPoint.Data.IntegrationTests;

public class BaseRepositoryTests
{
    protected static string ConnectionString { get; } = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PrescriberPoint;User ID=prescriberpoint;Password=prescriberpoint;Connect Timeout=60;Encrypt=False;";

    protected IOptions<DbOptions> DbOptions { get; } = Options.Create(new DbOptions
    {
        DefaultConnection = ConnectionString
    });
}