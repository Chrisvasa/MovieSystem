using Microsoft.AspNetCore.Builder;

namespace MovieSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "Hello world");

            app.Run();
        }
    }
}