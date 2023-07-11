using Microsoft.Web.WebView2.WinForms;
using WinFormsApp1.Controller;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await web.EnsureCoreWebView2Async(null);
            web.CoreWebView2.Settings.IsWebMessageEnabled = true;
            string path = Path.Combine(Environment.CurrentDirectory, "Interface", "index.html");
            web.CoreWebView2.Navigate(path);
            web.CoreWebView2.AddHostObjectToScript("apiwebcontroller", new ApiWebController(web));
        }
    }


   
}