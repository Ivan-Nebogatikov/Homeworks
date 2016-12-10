using System;
using System.Drawing;

namespace Homework4
{
    /// <summary>
    /// Class for lines to 
    /// </summary>
    public class Line
    {
        private readonly Pen pen = new Pen(Color.Black, 2);

        /// <summary>
        /// First line coordinate
        /// </summary>
        public Point Begin { get; set; }

        /// <summary>
        /// Second line coordinate
        /// </summary>
        public Point End { get; set; }

        /// <summary>
        /// Line constructor
        /// </summary>
        /// <param name="begin"> First point coordinate </param>
        /// <param name="end"> Second point coordinate </param>
        public Line(Point begin, Point end)
        {
            Begin = begin;
            End = end;
        }

        /// <summary>
        /// Draw the line on canvas
        /// </summary>
        /// <param name="graphics"> Graphics for drawing </param>
        public void Draw(Graphics graphics) =>
            graphics.DrawLine(pen, Begin.X, Begin.Y, End.X, End.Y);
        
    }
}
