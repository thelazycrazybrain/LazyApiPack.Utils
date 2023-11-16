using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LazyApiPack.Utils.Geometry;

namespace LazyApiPack.Utils.Math
{
    public static class GeometryMath
    {
        /// <summary>
        /// Replaces the number if value is NaN
        /// </summary>
        /// <param name="value">Value to replaced if it is NaN</param>
        /// <param name="substitute">Value that is used if value is NaN</param>
        /// <returns>value or substitute if value is NaN</returns>
        public static double ReplaceIfNaN(double value, double substitute = 0)
        {
            return double.IsNaN(value) ? substitute : value;
        }

        /// <summary>
        /// Returns a rectangle with positive dimensions
        /// </summary>
        /// <param name="x">Start point x</param>
        /// <param name="y">Start point y</param>
        /// <param name="width">Width of the rectangle</param>
        /// <param name="height">Height of the rectangle</param>
        /// <returns>A rectangle with positive dimensions.</returns>
        public static Rect GetNormalizedRect(double x, double y, double width, double height)
        {
            var x1 = width < 0 ? x + width : x;
            var y1 = height < 0 ? y + height : y;

            var width1 = width < 0 ? width * -1 : width;
            var height1 = height < 0 ? height * -1 : height;
            return new Rect(x1, y1, width1, height1);
        }

        /// <summary>
        /// Returns true, if left and top are within the rectangle.
        /// </summary>
        public static bool IsPointInRectangle(Point point, Rect rectangle)
        {
            return point.X >= rectangle.X && point.Y >= rectangle.Y &&
                point.X <= rectangle.X + rectangle.Width &&
                point.Y <= rectangle.Y + rectangle.Height;
        }

        /// <summary>
        /// Returns true if rectB is completely within rectA.
        /// </summary>
        /// <param name="rectA"></param>
        /// <param name="rectB"></param>
        /// <returns></returns>
        public static bool IsRectInRect(Rect rectA, Rect rectB)
        {
            return rectA.X <= rectB.X &&
                rectA.Y <= rectB.Y &&
                rectA.X + rectA.Width >= rectB.X + rectB.Width &&
                rectA.Y + rectA.Height >= rectB.Y + rectB.Height;
        }

        public static bool RectsOverlap(Rect rectA, Rect rectB)
        {
            return rectA.X < rectB.X + rectB.Width && rectA.X + rectA.Width > rectB.X &&
                    rectA.Y < rectB.Y + rectB.Height && rectA.Y + rectA.Height > rectB.Y;
        }
    }
}
