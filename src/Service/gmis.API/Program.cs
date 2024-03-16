using gmis.Application;
using gmis.Infrastructure;
using gmis.API.Configuration;
using gmis.API.Swagger;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
string SpecificOrigins = nameof(SpecificOrigins);

// Add services to the container.
builder.Host.AddConfigurations();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerServices(builder.Configuration);

builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration
        .ReadFrom.Configuration(hostingContext.Configuration)
        .Enrich.FromLogContext()
        .Enrich.WithProperty("ApplicationName", typeof(Program).Assembly.GetName().Name)
        .Enrich.WithProperty("Environment", hostingContext.HostingEnvironment);
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy(SpecificOrigins,
        builder => builder
        .WithOrigins("*")
        .AllowAnyHeader()
        .AllowAnyMethod()
        );
});



var app = builder.Build();
app.UseStaticFiles();
app.UseCors(SpecificOrigins);
//await app.Services.InitializeDatabasesAsync();
app.UseInfrastructure(builder.Configuration);
app.UseSerilogRequestLogging();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
