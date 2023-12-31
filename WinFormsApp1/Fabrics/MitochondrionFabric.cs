﻿using Cito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cito.Fabrics
{
    internal class MitochondrionFabric : _FabricContainer
    {
        static Random random = new Random();
        public static MitochondrionModel CreateMitochondrion()
        {
            int size = 80;
            var mito = new MitochondrionModel()
            {
                Style = new StyleModel()
                {
                    X = random.Next(20, size - 20) + "px",
                    Y = random.Next(20, size - 20) + "px",
                    Transform = $"rotate({random.Next(0, 360)}deg)"
                }
            };
            Type key = typeof(MitochondrionModel);
            if (Container.ContainsKey(key))
            {
                var appendConfiguration = Container[key];
                appendConfiguration(mito);
            }
            return mito;
        }
        public static List< MitochondrionModel>  CreateMitochondrions( int count = 3)
        {
            MitochondrionModel[] mitochondrions = new MitochondrionModel[count];
            
            for (int i = 0;i < count;i ++)
            {
                mitochondrions[i] = CreateMitochondrion();
            }
            return mitochondrions.ToList();
        }
    }
}
