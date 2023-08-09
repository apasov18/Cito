using Cito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cito.Extantions
{
    internal static class HandlerExtensions
    {
        static Regex regex = new Regex("([0-9]+)px|([0-9]+)%");
        static Random random  = new Random();
        static string dna = "ATGC";
        public static double GetSize(this string str)
        {
            var colection = regex.Match(str);
            return double.Parse(colection.Groups[1].Value);

        }

        public static string GenerateDNA(int lengts )
        {
            StringBuilder result = new StringBuilder();
            for ( int i = 0; i < lengts; i++ )
            {
                result.Append(dna[random.Next(0,dna.Length)]);
            }
            return result.ToString();
        }
        public static CellModel ClosetCell(this CellModel cell,List<CellModel> cells )
        {
            return cells.MinBy(c => cell.GetDistance(c))!;
        }

        public static double GetDistance(this CellModel cell,CellModel other)
        {
            double cellX = cell.Style.X.GetSize();
            double cellY = cell.Style.Y.GetSize();
            double otherX = other.Style.X.GetSize();
            double otherY = other.Style.Y.GetSize();

            return Math.Sqrt(Math.Pow(cellX - otherX, 2) + Math.Pow(cellY - otherY, 2));
        }

        public static void MoveClose(this CellModel cell, CellModel other,int speed)
        {
            double cellX = cell.Style.X.GetSize();
            double cellY = cell.Style.Y.GetSize();
            double otherX = other.Style.X.GetSize();
            double otherY = other.Style.Y.GetSize();

            cellX += cellX < otherX ? speed : speed * -1;
            cellY += cellY < otherY ? speed : speed * -1;


            cell.Style.X = $"{cellX}px";
            cell.Style.Y = $"{cellY}px";
        }

        public static void MoveAwait(this CellModel cell, CellModel other, int speed)
        {
            double cellX = cell.Style.X.GetSize();
            double cellY = cell.Style.Y.GetSize();
            double otherX = other.Style.X.GetSize();
            double otherY = other.Style.Y.GetSize();

            cellX -= cellX < otherX ? speed : speed * -1;
            cellY -= cellY < otherY ? speed : speed * -1;


            cell.Style.X = $"{cellX}px";
            cell.Style.Y = $"{cellY}px";
        }
        public static void MoveClose(this CellModel cell, Point other, int speed)
        {
            double cellX = cell.Style.X.GetSize();
            double cellY = cell.Style.Y.GetSize();
            double otherX = other.X;
            double otherY = other.Y;

            cellX -= cellX < otherX ? speed : speed * -1;
            cellY -= cellY < otherY ? speed : speed * -1;


            cell.Style.X = $"{cellX}px";
            cell.Style.Y = $"{cellY}px";
        }


    }
}
