﻿using Cito.Models;
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
        static Random random = new Random();
        Regex regex = new Regex("([0-9]+)px");

        public override StyleModel LifeRequest(CellModel cell)
        {
            if (cell.Energy < 20)
            {
                string px = cell.Style.X;
                var colection = regex.Match(px);
                double newPos = double.Parse(colection.Groups[1].Value);
                newPos -= 10;
                cell.Style.X = $"{newPos}px";
                cell.Energy -= 10;
                return cell.Style;
            }
            return base.LifeRequest(cell);
        }
    }
}
