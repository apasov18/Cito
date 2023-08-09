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
    internal class DNACharacteristicHandler : Handler
    {

        public override void LifeRequest(RequestModel request)
        {
            if (request.Cell.DNA[4]=='T')
            {
                request.Cell.Life += 3;
                
            }
            else if (request.Cell.DNA[4] == 'A')
            {
                request.Cell.Life += 8;

            }
            else if (request.Cell.DNA[4] == 'G')
            {
                request.Cell.Life += 8;

            }
            else if (request.Cell.DNA[4] == 'C')
            {
                request.Cell.Life += 10;

            }

            base.LifeRequest(request);
        }
    }
}
