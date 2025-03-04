using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ServerAspnet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowAll",
                    policy =>
                    {
                        policy
                            .WithOrigins("http://localhost:4321") // La URL de tu frontend en Astro
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials(); // Permitir el envío de credenciales (cookies, headers de autenticación)
                    }
                );
            });

            builder.Services.AddSignalR();
            builder
                .Services.AddControllers()
                .PartManager.ApplicationParts.Add(new AssemblyPart(typeof(Program).Assembly));

#if DEBUG
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
#endif

            var app = builder.Build();

#if DEBUG
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
#endif

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.UseDefaultFiles(); // <-- Sirve index.html por defecto
            app.UseStaticFiles(); // <-- Sirve archivos de wwwroot

            app.MapGet("/api/demo", () => new { message = "¡Funciona! 🎉" });
            app.MapHub<ClockHub>("/clockHub");

            if (args.Any(x => x == "run_async"))
                app.RunAsync();
            else
                app.Run();
        }
    }
}
