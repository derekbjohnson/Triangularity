using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Triangularity.Models
{
    public class Triangle
    {
        private int _LegSize = 10;
        public int LegSize
        {
            get { return _LegSize; }
            set
            {
                if (value < 1 || value > int.MaxValue)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be greater than 0 and less than 2147483647");
                _LegSize = value;
            }
        }
        public Point Vertex1 { get; set; }
        public Point Vertex2 { get; set; }
        public Point Vertex3 { get; set; }

        //Valid is defined as vertex 2 is the leftmost and vertex 3 is the rightmost
        //Vertex 1 is variable based on orientation
        public bool IsValid()
        {
            return Vertex2.X < Vertex3.X && Vertex2.Y < Vertex3.Y;
        }
    }

}
