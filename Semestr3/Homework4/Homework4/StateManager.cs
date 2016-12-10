using System.Collections.Generic;
using System.Drawing;

namespace Homework4
{
    /// <summary>
    /// Class for state management
    /// </summary>
    public class StateManager
    {
        private readonly Stack<List<Line>> states;

        private List<Line> currentState;

        private readonly Stack<List<Line>> redo;

        private bool changingLine = false;

        /// <summary>
        /// Class constructor
        /// </summary>
        public StateManager()
        {
            states = new Stack<List<Line>>();
            redo = new Stack<List<Line>>();
            currentState = new List<Line>();
        }

        /// <summary>
        /// Current set of lines
        /// </summary>
        /// <returns> List of current lines </returns>
        public List<Line> GetCurrentState() => currentState;

        /// <summary>
        /// Remove special line from current state for changing its position
        /// </summary>
        /// <param name="number"> Number of this line </param>
        public void RemoveLine(int number)
        {
            states.Push(new List<Line>(currentState));
            currentState.RemoveAt(number);
            changingLine = true;
        }

        /// <summary>
        /// Checks is states collection empty
        /// </summary>
        /// <returns> True if empty </returns>
        public bool IsStatesEmpty() => states.Count == 0;

        /// <summary>
        /// Adding new line
        /// </summary>
        /// <param name="newLine"> Line to adding </param>
        public void PushLine(Line newLine)
        {
            if (!changingLine)
            {
                states.Push(new List<Line>(currentState));
            }
            currentState.Add(newLine);
            changingLine = false;
        }

        /// <summary>
        /// Clear redo collection
        /// </summary>
        public void RedoClear() =>
            redo.Clear();

        /// <summary>
        /// Do redo
        /// </summary>
        public void Redo()
        {
            states.Push(new List<Line>(currentState));
            currentState = new List<Line>(redo.Pop());
        }

        /// <summary>
        /// Do undo
        /// </summary>
        public void Undo()
        {
            redo.Push(new List<Line>(currentState));
            currentState = new List<Line>(states.Pop());
        }

        /// <summary>
        /// Checks is redo collection empty
        /// </summary>
        /// <returns></returns>
        public bool IsRedoEmpty() =>
            redo.Count == 0;

        /// <summary>
        /// Draw all lines at the current state
        /// </summary>
        /// <param name="graphics"> Graphics for painting </param>
        public void DrawCurrentState(Graphics graphics)
        {
            foreach (var line in currentState)
            {
                line.Draw(graphics);
            }
        }
    }
}
