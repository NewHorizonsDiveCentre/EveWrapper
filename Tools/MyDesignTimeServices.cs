using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Microsoft.Extensions.DependencyInjection;

public class MyDesignTimeServices : IDesignTimeServices
{
    public void ConfigureDesignTimeServices(IServiceCollection services)
    {
        services.AddSingleton<ICandidateNamingService, MyCandidateNamingService>();
        services.AddSingleton<ICSharpDbContextGenerator, MyCSharpDbContextGenerator>();
    }
}
