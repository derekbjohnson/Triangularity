using System;
using System.ComponentModel.DataAnnotations;

namespace Triangularity.Models
{
    public class Triangle
    {
        private int legSize = 10;
        public Point Vertex1 { get; set; }
        public Point Vertex2 { get; set; }
        public Point Vertex3 { get; set; }
        public Triangle() { }

        public Triangle(int v1x, int v1y, int v2x, int v2y, int v3x, int v3y)
        {
            Vertex1 = new Point(v1x, v1y);
            Vertex2 = new Point(v2x, v2y);
            Vertex3 = new Point(v3x, v3y);
        }
        
        [Required]
        [Range(1,int.MaxValue,ErrorMessage = "The leg size should be greater than 1 and less than 2147483647")]
        public int LegSize
        {
            get => legSize;
            set
            {
                if (value < 1 || value > int.MaxValue)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be greater than 0 and less than 2147483647");
                legSize = value;
            }
        }

        /// <summary>
        /// A triangular is valid iif verext 2 is the leftmost and vertex 3 is the rightmost. Vertex 1 is variable
        /// based on the orientation.
        /// </summary>
        /// <returns>true when valid, false otherwise</returns>
        public bool IsValid()
        {
            return Vertex2.X < Vertex3.X && Vertex2.Y < Vertex3.Y;
        }

        public override string ToString()
        {
            return string.Format("[ {0}, {1}, {2} ]", Vertex1.ToString(), Vertex2.ToString(), Vertex3.ToString());
        }
    }
}
