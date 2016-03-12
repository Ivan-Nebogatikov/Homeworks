namespace Problem4
{
    /// <summary>
    /// Main program class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main program method
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var eventLoop = new EventLoop();
            var cursorManager = new CursorManager();
            eventLoop.UpHandler += cursorManager.OnUp;
            eventLoop.RightHandler += cursorManager.OnRight;
            eventLoop.DownHandler += cursorManager.OnDown;
            eventLoop.LeftHandler += cursorManager.OnLeft;
            eventLoop.Run();
        }
    }
}
