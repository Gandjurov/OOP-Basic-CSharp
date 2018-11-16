using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double Length
        {
            get { return length; }
            set { length = value; }
        }

        private double Width
        {
            get { return width; }
            set { width = value; }
        }
        
        private double Height
        {
            get { return height; }
            set { height = value; }
        }

        public string GetSurfaceArea()
        {
            double surfaceArea = 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;

            return $"Surface Area - {surfaceArea:F2}";
        }

        public string GetLateralSurfaceArea()
        {
            double lateralSurfaceArea = 2 * Length * Height + 2 * Width * Height;

            return $"Lateral Surface Area - {lateralSurfaceArea:F2}";
        }

        public string GetVolume()
        {
            double volume = Length * Width * Height;

            return $"Volume - {volume:F2}";
        }
    }
}
