using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.LiskovSub.Good
{
    public class Square : IAreaCalculator
    {
        private int _side;

        public Square(int side)
        {
            _side = side;
        }

        public int GetArea()
        {
            return _side * _side;
        }
    }
}
