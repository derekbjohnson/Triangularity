using Xunit;
using Triangularity.Models;

namespace Triangularity.Tests
{
    public class ImageTests
    {
        [Theory]
        [InlineData('b',3,10,20,10,10,20,20)]
        [InlineData('c',10,50,20,40,20,50,30)]
        public void GetVerticesByRowCol_ShouldBeLocated(char row, int col, int v1x, int v1y, int v2x, int v2y, int v3x, int v3y)
        {
            var img = new Image();

            var expected = new Triangle
            {
                Vertex1 = new Point(v1x, v1y),
                Vertex2 = new Point(v2x, v2y),
                Vertex3 = new Point(v3x, v3y)
            };

            var actual = img.GetVerticesByRowCol(row, col);

            Assert.Equal(expected.Vertex1, actual.Vertex1);
            Assert.Equal(expected.Vertex2, actual.Vertex2);
            Assert.Equal(expected.Vertex3, actual.Vertex3);
        }

        [Theory]
        [InlineData(-1,-1,-1,-1,-1,-1)]
        [InlineData(10, 20, 10, 10, 20, 25)]
        [InlineData(50, 20, 60, 20, 50, 30)]
        public void GetLocationByVertices_Invalid(int v1x, int v1y, int v2x, int v2y, int v3x, int v3y)
        {
            var img = new Image();

            Assert.Null(img.GetLocationByVertices(v1x, v1y, v2x, v2y, v3x, v3y));
        }

        [Theory]
        [InlineData("B3", 10, 20, 10, 10, 20, 20)]
        [InlineData("C10", 50, 20, 40, 20, 50, 30)]
        public void GetLocationByVertices_ShouldBeLocated(string expected, int v1x, int v1y, int v2x, int v2y, int v3x, int v3y)
        {
            var img = new Image();

            var actual = img.GetLocationByVertices(v1x, v1y, v2x, v2y, v3x, v3y);

            Assert.Equal(expected, actual);

        }
    }
}
