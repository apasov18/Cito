
using Cito.Extantions;
using Cito.Models;
using Cito.WinFormsApp1;
using System.Security.Cryptography.Pkcs;

namespace WinFormsApp1
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            Random random = new Random ();
            Configuration config = new Configuration();
            config.Configure<CellModel>(cell =>
            {
                cell.Id = Guid.NewGuid();
                cell.Style.Width = "100px";
                cell.Style.Height = "100px";
                cell.Energy = random.Next(20, 300);
                cell.Life = random.Next(20, 150);
                cell.DNA = HandlerExtensions.GenerateDNA(random.Next(10, 30));

            });
            


            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}