﻿using Cito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cito.Fabrics
{
    internal class CellFabric :_FabricContainer 
    {
        static Random random = new Random();
        public static CellModel CreateCell()
        {
            int size = random.Next(100, 170);
            var cell =  new CellModel()
            {

                Life = 100,
                Style = new StyleModel()
                {
                    Height = size + "px",
                    Width = size + "px",
                    X = random.Next(0, 600) + "px",
                    Y = random.Next(0, 600) + "px",
                },
                Mitochondrion = MitochondrionFabric.CreateMitochondrions(random.Next(1, 5)),
                Lysosomes = LysosomeFabric.CreateLysosomes(random.Next(1, 5)),
            };
            Type key = typeof(CellModel);
            if (Container.ContainsKey(key))
            {
                var appendConfiguration = Container[key];
                appendConfiguration(cell);
            }



            return cell;
        }

        public static CellModel[] CreateCells(int count = 3)
        {
            CellModel[] cells = new CellModel[count];
            for (int i = 0; i < count; i++)
            {
                cells[i] = CreateCell();
               
            }
            return cells;
        }



    }
}
