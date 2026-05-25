using cwiczenia5.Repositories;
using cwiczenia5.Services;

namespace cwiczenia5;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        
        builder.Services.AddControllers();
        
        // Register repositories
        builder.Services.AddScoped<IRoomRepository, RoomRepository>();
        builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

        // Register services
        builder.Services.AddScoped<IRoomService, RoomService>();
        builder.Services.AddScoped<IReservationService, ReservationService>();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }
        
        app.MapControllers();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.Run();
    }
}