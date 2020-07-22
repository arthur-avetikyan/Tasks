using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.LiskovSub.Good
{
    public class GoodRectangle : IAreaCalculator
    {
        protected int _height;
        protected int _width;

        public GoodRectangle(int height, int width)
        {
            _height = height;
            _width = width;
        }

        public int GetArea()
        {
            return _height * _width;
        }
    }
}
