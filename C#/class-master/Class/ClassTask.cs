using System;
using System.Collections.Generic;
using System.Linq;

namespace Class
{
    public class Rectangle
    {
        #region Fields
        private double sideA;
        private double sideB;
        #endregion
        #region Constructors
        public Rectangle(double a, double b)
        {
            this.sideA = a;
            this.sideB = b;
        }
        public Rectangle(double a)
        {
            this.sideA = a;
            this.sideB = 5;
        }
        public Rectangle()
        {
            this.sideA = 4;
            this.sideB = 3;
        }
        #endregion Constructors
        #region Methods
        public double GetSideA()
        {
            return sideA;
        }
        public double GetSideB()
        {
            return sideB;
        }

        public double Area()
        {
            return sideA * sideB;
        }

        public double Perimeter()
        {
            return (sideA + sideB) * 2;
        }

        public bool IsSquare()
        {
            if (this.sideA == this.sideB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ReplaceSides()
        {
            double temp;
            temp = this.sideA;
            this.sideA = this.sideB;
            this.sideB = temp;
        }
        #endregion Methods
    }
    public class ArrayRectangles
    {
        #region Fields
        private readonly Rectangle[] rectangle_array;
        #endregion
        #region Constructors
        public ArrayRectangles(int n = 0)
        {
            rectangle_array = new Rectangle[n];
        }
        public ArrayRectangles(IEnumerable<Rectangle> rectangles)
        {
            this.rectangle_array = rectangles.ToArray();
        }
        #endregion
        #region Methods
        public bool AddRectangle(Rectangle rectangle)
        {
            for (int rect = 0; rect < rectangle_array.Length; rect++)
            {
                //Checking has array free place
                if (rectangle_array[rect] is null)
                {
                    rectangle_array[rect] = rectangle;
                    return true;
                }
            }
            return false;

        }
        public int NumberMaxArea()
        {
            //Takes first element of array to compare to other elements
            var max = rectangle_array[0];
            int index = 0;
            for (int i = 1; i < rectangle_array.Length; i++)
            {
                if (rectangle_array[i].Area() > max.Area())
                {
                    max = rectangle_array[i];
                    index = i;
                }
            }
            return index;
        }
        public int NumberMinPerimeter()
        {
            //Takes first element of array to compare to other elements
            var min = rectangle_array[0];
            int index = 0;
            for (int i = 1; i < rectangle_array.Length; i++)
            {
                if (rectangle_array[i].Perimeter() < min.Perimeter())
                {
                    min = rectangle_array[i];
                    index = i;
                }
            }
            return index;
        }
        public int NumberSquare()
        {
            int squareNum = 0;
            for (int rect = 0; rect < rectangle_array.Length; rect++)
            {
                if (rectangle_array[rect].IsSquare())
                {
                    squareNum++;
                }
            }
            return squareNum;
        }
        #endregion Methods
    }
}