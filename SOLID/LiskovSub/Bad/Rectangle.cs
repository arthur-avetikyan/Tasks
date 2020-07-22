namespace SOLID.LiskovSub.Bad
{
    public class Rectangle
    {
        public int Height { get; set; }

        public int Width { get; set; }

        public virtual int GetArea()
        {
            return Height * Width;
        }
    }

    public class Square : Rectangle
    {
        public int Side { get; set; }

        public override int GetArea()
        {
            if (Side > 0)
            {
                Width = Side;
                Height = Side;
            }
            else
            {
                Width = Height;
            }
            return base.GetArea();
        }
    }
}
