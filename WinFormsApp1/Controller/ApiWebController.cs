using Cito.Controller;
using Cito.Fabrics;
using Cito.Handlears;
using Cito.Models;
using Cito.WinFormsApp1;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinFormsApp1.Controller
{
    public class ApiWebController : BaseController
    {
        Handler _cellHandler;
        public ApiWebController(WebView2 web) : base(web)
        {
            DNAFirstHandler first = new DNAFirstHandler();
            DNASecondHandler second = new DNASecondHandler();
            DNAThirdHandler third = new DNAThirdHandler();

            first.SetNextHandler(second);
            second.SetNextHandler(third);
            _cellHandler = first;

        }
        Random random = new Random();
        public async void LoadCells()
        {



            int count = 3;

            var cells = CellFabric.CreateCells(count);

            Json(cells, "LoadCells");

        }

        public async void UpdateCells(string json)
        {
            List<CellModel> cells = JsonSerializer.Deserialize<List<CellModel>>(json)!;

            cells.ForEach(cell =>
            {
                StyleModel style = _cellHandler.LifeRequest(cell);
                if (style != null)
                {
                    cell.Style = style;
                }
                //else
                //{
                //    cells.Remove(cell);
                //}
            });


            //cells.Add(CellFabric.CreateCell());

            Json(cells, "UpdateCells");


        }
    }
}
