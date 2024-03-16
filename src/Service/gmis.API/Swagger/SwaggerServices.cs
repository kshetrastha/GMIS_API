using Microsoft.OpenApi.Models;
using gmis.Application.Common.Helper;

namespace gmis.API.Swagger
{
    public static class SwaggerServices
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services, IConfiguration config)
        {
            var swaggerSettings = config.GetSection(nameof(SwaggerSettings)).Get<SwaggerSettings>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GMIS", Version = "v1" });
                c.AddSecurityDefinition(swaggerSettings.AuthenticationScheme,
                new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = swaggerSettings.HeaderName, // Authorization
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = swaggerSettings.BearerPrefix
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
               {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = swaggerSettings.AuthenticationScheme
                        }
                    },
                    new List<string>()
                }
               });
            });
            return services;
        }

        public static IApplicationBuilder configureSwagger(this IApplicationBuilder builder, IConfiguration config)
        {
            builder.UseDeveloperExceptionPage();
            builder.UseSwagger();
            builder.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "GMIS"); });
            return builder;
        }
    }
}
