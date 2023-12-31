﻿using Cito.Extantions;
using Cito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cito.Handlears
{
    internal class DNASecondHandler : Handler
    {

        public override void LifeRequest(RequestModel request)
        {
            if (request.Cell.DNA[4]=='T')
            {
                request.Cell.Energy += 25;
                
            }
            else if (request.Cell.DNA[4] == 'A')
            {
                request.Cell.Energy += 5;

            }
            else if (request.Cell.DNA[4] == 'G')
            {
                request.Cell.Energy += 8;

            }
            else if (request.Cell.DNA[4] == 'C')
            {
                request.Cell.Energy += 2;

            }

            base.LifeRequest(request);
        }
    }
}
