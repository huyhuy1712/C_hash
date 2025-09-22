using MilkTea.Client.Forms;
using System;
using System.Windows.Forms;

namespace MilkTea.Client
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
