using Cito.Fabrics;
using Cito.Models;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public async void LoadCells()
        {
            int count = 3;
           
            var cells = CellFabric.CreateCells(count);



            var json = JsonSerializer.Serialize(cells);
            _web.CoreWebView2.PostWebMessageAsJson(json);
        }


       

    }
}
