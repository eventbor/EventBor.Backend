using EventBor.Backend.Infrastructure;

namespace EventBor.Backend.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddInfrastructure(builder.Configuration);

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}