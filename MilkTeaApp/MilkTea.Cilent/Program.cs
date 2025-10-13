using MilkTea.Client.Forms;
using MilkTea.Client.Services;
using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;


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

            // 3. Đăng ký Form (có thể inject service vào Form)
      
            services.AddTransient<MainForm>();
            services.AddTransient<LoginForm>();

            // 4. Build provider
            ServiceProvider = services.BuildServiceProvider();

            // 5. Lấy MainForm từ DI
            //var mainForm = ServiceProvider.GetRequiredService<MainForm>();
            //Application.Run(new MainForm()); 

            var loginForm = ServiceProvider.GetRequiredService<LoginForm>();
            Application.Run(loginForm);
        }
    }
}
