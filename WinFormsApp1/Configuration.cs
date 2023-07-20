using Cito.Fabrics;
using Cito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cito.WinFormsApp1
{
    internal class Configuration : _FabricContainer
    {
        protected static Dictionary <string,string > Config { get; set; }
         static  Configuration( )
        {
            Config = new Dictionary<string, string>();
            Container = new Dictionary<Type, Action<object>>();
        } 
        
        public void Configure<T> (Action<T> action)
        {
            Action<object> configInitialize = (obj) =>
            {
                T config = (T)obj;
                action(config);
            };
            Type key = typeof(T);
            Container[key] = configInitialize;


        }
        public string this[string key] 
        {
            get
            {
                if (Config.TryGetValue(key,out string? result ))
                {
                    return result;                
                }
                return " ";
            }
        }
    }
}
