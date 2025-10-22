using Microsoft.Extensions.DependencyInjection;
using MilkTea.Client.Forms;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Net.Http;
using System.Windows.Forms;


namespace MilkTea.Client
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        [STAThread]
        static void Main()
        {
                ApplicationConfiguration.Initialize();
                // 1. Tạo service collection
                var services = new ServiceCollection();

                // 2. Đăng ký HttpClient + service
                services.AddSingleton<HttpClient>();
                services.AddTransient<TaiKhoanService>();
                services.AddSingleton<TaiKhoan>();

            // 3. Đăng ký Form (có thể inject service vào Form)

            services.AddTransient<MainForm>();
            services.AddTransient<LoginForm>();
            services.AddTransient<ImportForm>();

            // 4. Build provider
            ServiceProvider = services.BuildServiceProvider();

                // 5. Lấy MainForm từ DI
                //var mainForm = ServiceProvider.GetRequiredService<MainForm>();
                //Application.Run(new MainForm()); 

                var loginForm = ServiceProvider.GetRequiredService<LoginForm>();
                var mainForm = ServiceProvider.GetRequiredService<MainForm>();
                var importForm = ServiceProvider.GetRequiredService<ImportForm>();

            Application.Run(loginForm);
        }
    }
}
