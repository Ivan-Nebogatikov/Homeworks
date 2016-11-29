using System;
using System.Collections.Generic;
using System.Drawing;

namespace Homework4
{
    /// <summary>
    /// Class for state management
    /// </summary>
    public class StateManager
    {
        /// <summary>
        /// Stack of program states
        /// </summary>
        public Stack<List<Tuple<Point, Point>>> States { get; set; }

        /// <summary>
        /// Stack for redo actions
        /// </summary>
        public Stack<List<Tuple<Point, Point>>> Redo { get; set; }

        /// <summary>
        /// Class constructor
        /// </summary>
        public StateManager()
        {
            States = new Stack<List<Tuple<Point, Point>>>();
            Redo = new Stack<List<Tuple<Point, Point>>>();
        }
    }
}
