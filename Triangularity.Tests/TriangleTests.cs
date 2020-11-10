using Xunit;
using Triangularity.Models;
using System.Drawing;
using System;

namespace Triangularity.Tests
{
    public class TriangleTests
    {
        [Fact]
        public void TriangleInvalid()
        {
            var testTriangle = new Triangle()
            {
                Vertex1 = new Point(0, 0),
                Vertex2 = new Point(10, 0),
                Vertex3 = new Point(0, 10)
            };
            Assert.Throws<ArgumentOutOfRangeException>(() => testTriangle.LegSize = 0);
            Assert.False(testTriangle.IsValid());
        }
    }
}
