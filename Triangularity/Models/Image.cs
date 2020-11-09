using System;
using System.Collections.Generic;
using System.Drawing;

namespace Triangularity.Models
{
    public class Image
    {

        public int ImageSize { get; set; } = 60;
        public int TriangleLegSize { get; set; } = 10;

        public List<Point> GetAllVertices()
        {
            try
            {
                return new List<Point>(6);
            }
            catch { return null; }
        }

        public Triangle GetVerticesByRowCol(char row, int column)
        {
            // Vertex 1 will be dependent on the triangle's orientation
            // Vertices 2 and 3 will be the same for each column
            try
            {
                bool isLower = column % 2 == 0;
                int ColVal = isLower ? (column / 2) : (column / 2) + 1;
                int RowVal = char.ToUpper(row) - 64; // ASCII is fun

                var outTriangle = new Triangle
                {
                    LegSize = TriangleLegSize,
                    Vertex1 = isLower ? new Point(x: TriangleLegSize * (ColVal - 1), y: TriangleLegSize * RowVal)
                                      : new Point(x: TriangleLegSize * ColVal, y: TriangleLegSize * (RowVal - 1)),
                    Vertex2 = new Point(x: TriangleLegSize * (ColVal - 1), y: TriangleLegSize * (RowVal - 1)),
                    Vertex3 = new Point(x: TriangleLegSize * ColVal, y: TriangleLegSize * RowVal),
                };
                return outTriangle;
            }
            catch (Exception)
            {
                return new Triangle();
            }
        }
    }
}
