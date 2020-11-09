using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Triangularity.Models
{
    public class Triangle
    {
        public int LegSize { get; set; } = 10;
        public Point Vertex1 { get; set; }
        public Point Vertex2 { get; set; }
        public Point Vertex3 { get; set; }
    }

}
