
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
#if DEBUG
                        .WithOrigins("http://localhost:4321")
#endif
                        .AllowAnyMethod().AllowAnyHeader();
                    }
                );
            });

            builder.Services.AddControllers().PartManager.ApplicationParts.Add(new AssemblyPart(typeof(Program).Assembly));

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
            app.UseStaticFiles();  // <-- Sirve archivos de wwwroot
  
            app.MapGet("/api/demo", () => new { message = "¡Funciona! 🎉" });

            if(args.Any(x=> x=="run_async")) app.RunAsync();
            else app.Run();

        }
    }
}
