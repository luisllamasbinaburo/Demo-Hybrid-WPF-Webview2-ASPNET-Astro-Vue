using System.Windows;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace AppWPF
{
    public class WebServer
    {
        public void Start()
        {
            try
            {
                Console.WriteLine("Iniciando servidor web...");
                ServerAspnet.Program.Main(new string[] { "run_async" });
                Console.WriteLine("Iniciado...");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en el servidor: {ex.Message}");
            }
        }
    }
}
