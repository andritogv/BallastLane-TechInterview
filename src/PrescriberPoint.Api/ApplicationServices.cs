using PrescriberPoint.Business.Prescriptions;
using PrescriberPoint.Business.Repositories;
using PrescriberPoint.Data;

namespace PrescriberPoint.Api;

public static class ApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<DbOptions>(config.GetSection("ConnectionStrings"));

        services.AddSingleton<IPrescriptionService, PrescriptionService>();
        services.AddSingleton<IPrescriptionRepository, PrescriptionRepository>();

        return services;
    }
}