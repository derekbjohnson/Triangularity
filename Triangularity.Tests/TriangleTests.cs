using Xunit;
using Triangularity.Models;
using System;

namespace Triangularity.Tests
{
    public class TriangleTests
    {
        [Fact]
        public void TriangleInvalid()
        {
            var testTriangle = new Triangle
            {
                Vertex1 = new Point(0, 0),
                Vertex2 = new Point(10, 0),
                Vertex3 = new Point(0, 10)
            };
            Assert.Throws<ArgumentOutOfRangeException>(() => testTriangle.LegSize = 0);
            Assert.False(testTriangle.IsValid());
        }

        [Theory]
        [InlineData(10, 20, 10, 10, 20, 20)]
        [InlineData(50, 20, 40, 20, 50, 30)]
        public void Triangle_ShouldBeValid(int v1x, int v1y, int v2x, int v2y, int v3x, int v3y)
        {
            var Triangle = new Triangle(v1x, v1y, v2x, v2y, v3x, v3y);

            Assert.True(Triangle.IsValid());
        }

        [Theory]
        [InlineData(10, 20, 10, 10, 20, 25)]
        [InlineData(50, 20, 60, 20, 50, 30)]
        public void Triangle_ShouldBeInvalid(int v1x, int v1y, int v2x, int v2y, int v3x, int v3y)
        {
            var Triangle = new Triangle(v1x, v1y, v2x, v2y, v3x, v3y);

            Assert.False(Triangle.IsValid());
        }
    }
}
