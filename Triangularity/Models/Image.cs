using System;

namespace Triangularity.Models
{
    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return String.Format("( {0}, {1} )", x, y);
        }
    }
    public class Image
    {
        //TODO: Expand to determine which triangle would contain coordinate (single coordinate)

        //TODO: Confirm size and Triangle leg size are both greater than zero
        public int ImageSize { get; set; } = 60;

        //TODO: Determine if leg size is less than image size
        public int TriangleLegSize { get; set; } = 10;

        //TODO: Determine if vertices are appropriate size (According to leg size)?
        private bool IsValidVertex(int x, int y) => ((0 <= x) && (x <= ImageSize) && (0 <= y) && (y <= ImageSize));

        private bool IsValidLocation(char row, int column)
        {
            bool isValid = true;

            // Artificial constraint
            isValid = char.ToUpper(row) - 64 >= 1;

            return isValid;

        }

        public string GetLocationByVertices(int v1x, int v1y, int v2x, int v2y, int v3x, int v3y)
        {
            if (!IsValidVertex(v1x, v1y) || !IsValidVertex(v2x, v2y) || !IsValidVertex(v3x, v3y))
                return null;

            try
            {
                var row = (char)((v3y/TriangleLegSize) + 64);
                var col = (v1x / TriangleLegSize) + (v3x / TriangleLegSize);
                return row.ToString() + col.ToString();
            }
            catch 
            {
                return null;
            }
        }

        //TODO: Determine if row/col valid
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
                return null;
            }
        }

    }
}
