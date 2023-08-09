using Cito.Extantions;
using Cito.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cito.Handlears
{
    internal class DNAFirstHandler : Handler
    {

        public override void LifeRequest(RequestModel request)
        {
            if (request.Cell.Energy > request.Cell.DNA[0])
            {
                var style = request.Cell.Style;
                var w = style.Width.GetSize();
                var h = style.Height.GetSize();
                style.Width = $"{w + 2}px";
                style.Height = $"{w + 2}px";



            }
            base.LifeRequest(request);
        }
    }
}
