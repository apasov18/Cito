using Cito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cito.Fabrics
{
    internal class LysosomeFabric
    {
        static Random random = new Random();
        public static LysosomeModel CreateLysosome()
        {
            int size = random.Next(100, 300);
            return new LysosomeModel()
            {

                Style = new StyleModel()
                {
                    X = random.Next(20, size - 20) + "px",
                    Y = random.Next(20, size - 20) + "px",
                }
            };
        }

        public static List<LysosomeModel> CreateLysosomes(int count = 3)
        {
            LysosomeModel[] lysosomes = new LysosomeModel[count];

            for (int i = 0; i < count; i++)
            {
                lysosomes[i] = CreateLysosome();
            }
            return lysosomes.ToList();
        }

    }
}
