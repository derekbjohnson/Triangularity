using System;

namespace Triangularity.Models
{
    public class Image
    {
        //TODO: Confirm size and Triangle leg size are both greater than zero
        public int ImageSize { get; set; } = 60;

        //TODO: Determine if leg size is less than image size
        public int TriangleLegSize { get; set; } = 10;

        private bool IsValidVertex(int x, int y) => ((0 <= x) && (x <= ImageSize) && (0 <= y) && (y <= ImageSize));

        public string GetLocationByVertices(int v1x, int v1y, int v2x, int v2y, int v3x, int v3y)
        {
            if (!IsValidVertex(v1x, v1y) || !IsValidVertex(v2x, v2y) || !IsValidVertex(v3x, v3y))
                return null;

            var Triangle = new Triangle(v1x, v1y, v2x, v2y, v3x, v3y);

            if (!Triangle.IsValid())
                return null;

            try
            {
                var row = (char) ((v3y / TriangleLegSize) + 64);
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
                var isLower = column % 2 != 0;
                var ColVal = isLower ? (column / 2) + 1 : (column / 2);
                var RowVal = char.ToUpper(row) - 64; // ASCII is fun

                return new Triangle
                {
                    LegSize = TriangleLegSize,
                    Vertex1 = isLower ? new Point(x: TriangleLegSize * (ColVal - 1), y: TriangleLegSize * RowVal)
                                      : new Point(x: TriangleLegSize * ColVal, y: TriangleLegSize * (RowVal - 1)),
                    Vertex2 = new Point(x: TriangleLegSize * (ColVal - 1), y: TriangleLegSize * (RowVal - 1)),
                    Vertex3 = new Point(x: TriangleLegSize * ColVal, y: TriangleLegSize * RowVal),
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
