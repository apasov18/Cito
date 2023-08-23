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
        bool life = true;

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

        public void CallBackSpeech(string text ) 
        {
            List < string> words = text.ToLower().Split(new char[] {' ','.'}).ToList();
            int index = words.IndexOf("стоп");
            if(index!= -1)
            {
                life = !life;
            }

            int index2 = words.IndexOf("стартуем");

              if (index2!= -1)
            {
                life = true;
            }



        }

        public async void UpdateCells(string json)
        {
            List<CellModel> cells = JsonSerializer.Deserialize<List<CellModel>>(json)!;

            if (life)

            {
                cells.ForEach(cell =>
                {
                    var request = new RequestModel()
                    {
                        Cell = cell,
                        Cells = cells.Where(c => c.Id != cell.Id).ToList()
                    };
                    _cellHandler.LifeRequest(request);

                });

            }

            Json(cells, "UpdateCells");


        }
    }
}
