using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize the host
            using (var host = CreateHostBuilder().Build())
            {
                // Start the background service
                var dateChangeService = host.Services.GetRequiredService<DateChangeService>();
                dateChangeService.CheckForDateChange(); // Run the initial check
                host.Start();

                // Run the main form
                Application.Run(new MainMenu());

                // Stop the host when the main form is closed
                host.StopAsync().Wait();
            }
        }

        static IHostBuilder CreateHostBuilder() =>
            new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<DateChangeService>();
                });
    }

    public class DateChangeService : BackgroundService
    {
        private DateTime previousDate = DateTime.MinValue;

        protected override async Task ExecuteAsync(System.Threading.CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                CheckForDateChange();

                // Adjust the interval as needed
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }

        public void CheckForDateChange()
        {
            DateTime currentDate = DateTime.Now.Date;

            // Check if the date has changed
            if (currentDate > previousDate)
            {
                // Perform actions for the new day
                Console.WriteLine("The date has changed to the next day.");

                // Update the previous date
                previousDate = currentDate;
            }
        }
    }
}
