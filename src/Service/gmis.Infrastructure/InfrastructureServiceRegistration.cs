using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using gmis.Infrastructure.Middlewares.ExceptionMiddlewareSetup;
using gmis.Infrastructure.Persistence.Initialization;
using gmis.Infrastructure.Persistence;
using gmis.Infrastructure.Persistence.Context;
using gmis.Application.Contracts.Persistence.Base;
using gmis.Infrastructure.Repositories.Base;
using gmis.Infrastructure.Auth;
using gmis.Application.Contracts.Persistence;
using gmis.Infrastructure.Repositories.LOF;

namespace gmis.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            return services
                .AddAuth(config)
                .AddExceptionMiddleware()
                .AddPersistence(config)
                .AddServices();
        }

        public static async Task InitializeDatabasesAsync(this IServiceProvider services, CancellationToken cancellationToken = default)
        {
            // Create a new scope to retrieve scoped services
            using var scope = services.CreateScope();

            await scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>()
                .InitializeDatabasesAsync(cancellationToken);
        }
        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder builder, IConfiguration config) =>
         builder
         .UseExceptionMiddleware()
         .UseCurrentUser();
        internal static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            //services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            //services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            //services.AddScoped<IRegionRepository, RegionRepository>();
            //services.AddScoped<IRoleRepository, RoleRepository>();
            return services;
        }

        #region Register middle ware
        internal static IServiceCollection AddExceptionMiddleware(this IServiceCollection services) =>
      services.AddScoped<ExceptionMiddleware>();
        internal static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app) =>
            app.UseMiddleware<ExceptionMiddleware>();
        #endregion

        internal static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
        {
            var databaseSettings = config.GetSection(nameof(DatabaseSettings)).Get<DatabaseSettings>();
            string? rootConnectionString = databaseSettings.ConnectionString;
            services
                .AddDbContext<RepositoryContext>(options => options.UseSqlServer(rootConnectionString, e =>
                     e.MigrationsAssembly("gmis.API")))
                .AddTransient<IDatabaseInitializer, DatabaseInitializer>()
                //.AddTransient<ApplicationDbInitializer>()
                .AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            return services;
        }


    }
}
