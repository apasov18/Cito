using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WinFormsApp1.Controller
{
    public class ApiWebController
    {
        WebView2 _web;

        public ApiWebController(WebView2 web)
        {
            _web = web;
        }
        Random random = new Random();
        public async void GetPosition()
        {

            var message = new
            {
               left = random.Next(0,700) +"px",
               top = random.Next(0,700) + "px",

            };
            var json = JsonSerializer.Serialize(message);
            _web.CoreWebView2.PostWebMessageAsJson(json);
        }
    }
}
