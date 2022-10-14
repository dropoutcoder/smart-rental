
using SmartRental.Diagnostics;
using SmartRental.Hosting;
using SmartRental.Infrastructure.Extensions;

namespace SmartRental
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDatabase("SmartRental");

            builder.Services.AddOperations();

            builder.Services.AddHostedService<DataSeedHostingService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseMiddleware<ApiExceptionHandlerMiddleware>();

            app.MapControllers();

            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}