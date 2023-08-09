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
            var characteristics = new DNACharacteristicHandler();

            DNAThirdHandler third = new DNAThirdHandler();

            first.SetNextHandler(second);
            second.SetNextHandler(characteristics);
            characteristics.SetNextHandler(third);

            _cellHandler = first;

        }
        Random random = new Random();
        public async void LoadCells()
        {



            int count = 10;

            var cells = CellFabric.CreateCells(count);

            Json(cells, "LoadCells");

        }

        public async void UpdateCells(string json)
        {
            List<CellModel> cells = JsonSerializer.Deserialize<List<CellModel>>(json)!;

            cells.ForEach(cell =>
            {
                var request = new RequestModel()
                {
                    Cell = cell,
                    Cells = cells.Where(c => c.Id != cell.Id).ToList()
                };
                 _cellHandler.LifeRequest(request);
              
            });



            Json(cells, "UpdateCells");


        }
    }
}
