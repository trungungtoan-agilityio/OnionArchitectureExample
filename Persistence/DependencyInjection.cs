using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Persistence;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services, string connection)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                connection,
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        
        services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>() ?? throw new InvalidOperationException());
    }
}