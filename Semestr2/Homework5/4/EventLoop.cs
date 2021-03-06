﻿using System;

namespace Problem4
{
    /// <summary>
    /// Class for main loop
    /// </summary>
    public class EventLoop
    {
        /// <summary>
        /// Handler for up arrow
        /// </summary>
        public event EventHandler<EventArgs> UpHandler = (sender, args) => { };

        /// <summary>
        /// Handler for right arrow
        /// </summary>
        public event EventHandler<EventArgs> RightHandler = (sender, args) => { };

        /// <summary>
        /// Handler for down arrow
        /// </summary>
        public event EventHandler<EventArgs> DownHandler = (sender, args) => { };

        /// <summary>
        /// Handler for left arrow
        /// </summary>
        public event EventHandler<EventArgs> LeftHandler = (sender, args) => { };

        /// <summary>
        /// Main program loop
        /// </summary>
        public void Run()
        {
            while (true)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        LeftHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.RightArrow:
                        RightHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.UpArrow:
                        UpHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.DownArrow:
                        DownHandler(this, EventArgs.Empty);
                        break;
                }
            }
        }
    }

}
