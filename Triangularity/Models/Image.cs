using System;
using System.Collections.Generic;
using System.Drawing;

namespace Triangularity.Models
{
    public class Image
    {

        public int ImageSize { get; set; } = 60;
        public int TriangleLegSize { get; set; } = 10;

        public string GetLocationByVertices(int v1x, int v1y, int v2x, int v2y, int v3x, int v3y)
        {
            try
            {
                var row = (char)((v3y/TriangleLegSize) + 64);
                var col = (v1x / TriangleLegSize) + (v3x / TriangleLegSize);
                return "The triangle is located at " + row.ToString() + col.ToString();
            }
            catch 
            { 
                return "Unable to Locate Triangle"; 
            }
        }

        public Triangle GetVerticesByRowCol(char row, int column)
        {
            // Vertex 1 will be dependent on the triangle's orientation
            // Vertices 2 and 3 will be the same for each column
            try
            {
                bool isLower = column % 2 != 0;
                int ColVal = isLower ? (column / 2) + 1 : (column / 2);
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
