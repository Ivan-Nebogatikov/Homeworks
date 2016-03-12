using System;

namespace Problem4
{
    /// <summary>
    /// Cursor manager class
    /// </summary>
    public class CursorManager
    {
        /// <summary>
        /// Action for up arrow pressed
        /// </summary>
        /// <param name="sender"> Parent object </param>
        /// <param name="args"> Action parameters </param>
        public void OnUp(object sender, EventArgs args) =>
            Console.CursorTop = (Console.CursorTop <= 0) ? 0 : Console.CursorTop - 1;

        /// <summary>
        /// Action for right arrow pressed
        /// </summary>
        /// <param name="sender"> Parent object </param>
        /// <param name="args"> Action parameters </param>
        public void OnRight(object sender, EventArgs args) =>
            Console.CursorLeft = (Console.CursorLeft >= Console.WindowWidth - 1) ? Console.WindowWidth - 1 : Console.CursorLeft + 1;

        /// <summary>
        /// Action for down arrow pressed
        /// </summary>
        /// <param name="sender"> Parent object </param>
        /// <param name="args"> Action parameters </param>
        public void OnDown(object sender, EventArgs args) =>
            Console.CursorTop = (Console.CursorTop >= Console.WindowHeight - 1) ? Console.WindowHeight - 1 : Console.CursorTop + 1;

        /// <summary>
        /// Action for left arrow pressed
        /// </summary>
        /// <param name="sender"> Parent object </param>
        /// <param name="args"> Action parameters </param>
        public void OnLeft(object sender, EventArgs args) =>
            Console.CursorLeft = (Console.CursorLeft <= 0) ? 0 : Console.CursorLeft - 1;
    }
}
