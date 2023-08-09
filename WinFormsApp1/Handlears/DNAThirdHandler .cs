using Cito.Extantions;
using Cito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cito.Handlears
{
    internal class DNAThirdHandler : Handler
    {
      static Random random = new Random();

        public override void LifeRequest(RequestModel request)
        {
            if (request.Cell.Life < request.Cell.DNA[5])
            {
                var cell = request.Cell;
                var closest = cell.ClosetCell(request.Cells);
                cell.MoveAwait(closest, random.Next(10,50));
                request.Cell.Energy -= 8;
            }
            else if (request.Cell.Energy > request.Cell.DNA[6])
            {
                var cell = request.Cell;
                var closest = cell.ClosetCell(request.Cells);
                cell.MoveClose(closest, random.Next(10, 50));
                request.Cell.Energy -= 10;

            }
            else 
            {
                var cell = request.Cell;
                var closest = cell.ClosetCell(request.Cells);
                cell.MoveClose(new Point (1000,500), random.Next(10, 50));
                request.Cell.Energy -= 2;

            }
            base.LifeRequest(request);  
        }
    }
}
