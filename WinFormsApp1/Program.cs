
using Cito.Models;
using Cito.WinFormsApp1;

namespace WinFormsApp1
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            Configuration config = new Configuration();


            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}