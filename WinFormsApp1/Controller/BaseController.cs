using Cito.Models;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cito.Controller
{
    public abstract class BaseController
    {
        protected WebView2 Web { get; set; }
        public BaseController(WebView2 web) 
        {
            Web = web;
        
        }
        public virtual void Json( object obj,string method)
        {
            var eventModel = new EventControllerModel()
            {
                Data = obj,
                Method = method
            };

            var json = JsonSerializer.Serialize(eventModel);
            Web.CoreWebView2.PostWebMessageAsJson(json);
        }
    }
}
