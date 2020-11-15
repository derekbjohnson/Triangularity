namespace Triangularity.Models
{
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return string.Format("( {0}, {1} )", X, Y);
        }
    }
}