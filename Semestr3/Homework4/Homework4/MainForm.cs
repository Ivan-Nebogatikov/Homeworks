using System;
using System.Drawing;
using System.Windows.Forms;

namespace Homework4
{
    /// <summary>
    /// Main form class
    /// </summary>
    public partial class MainForm : Form
    {
        private bool isDrawing;
        private Point firstCoordinate;
        private StateManager stateManager = new StateManager();

        public MainForm()
        {
            InitializeComponent();
        }

        private void CanvasPaint(object sender, PaintEventArgs e)
        {
            canvas.Invalidate();
            var currentPoint = PointToClient(Cursor.Position);
            currentPoint.X -= canvas.Left;
            currentPoint.Y -= canvas.Top;
            if (isDrawing)
                new Line(firstCoordinate, currentPoint).Draw(e.Graphics);
            stateManager.DrawCurrentState(e.Graphics);
        }

        private void CanvasClick(object sender, EventArgs e)
        {
            isDrawing = !isDrawing;
            if (isDrawing)
            {
                SetItemsState(false);
                undoButton.Enabled = false;
                RedoButton.Enabled = false;
                firstCoordinate = PointToClient(Cursor.Position);
                firstCoordinate.X -= canvas.Left;
                firstCoordinate.Y -= canvas.Top;
            }
            else
            {
                choosingLineComboBox.Enabled = true;
                messageLabel.Text = "";
                var secondCoordinate = PointToClient(Cursor.Position);
                secondCoordinate.X -= canvas.Left;
                secondCoordinate.Y -= canvas.Top;
                choosingLineComboBox.Items.Add("Линия " + (choosingLineComboBox.Items.Count + 1));
                stateManager.PushLine(new Line(firstCoordinate, secondCoordinate));
                undoButton.Enabled = true;
                RedoButton.Enabled = false;
                stateManager.RedoClear();
            }
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            firstEndButton.Enabled = true;
            secondEndButton.Enabled = true;
            changingButton.Enabled = true;
        }

        private void ChangingButtonClick(object sender, EventArgs e)
        {
            if (choosingLineComboBox.SelectedIndex == -1)
            {
                messageLabel.Text = @"Линия не выбрана";
                return;
            }
            messageLabel.Text = @"Меняйте " + (firstEndButton.Checked ? firstEndButton : secondEndButton).Text + @"-й конец Линии №" + (choosingLineComboBox.SelectedIndex + 1);
            isDrawing = true;
            var state = stateManager.GetCurrentState();
            var line = state[choosingLineComboBox.SelectedIndex];
            stateManager.RemoveLine(choosingLineComboBox.SelectedIndex);
            choosingLineComboBox.Items.RemoveAt(choosingLineComboBox.Items.Count - 1);
            SetItemsState(false);
            firstCoordinate = firstEndButton.Checked ? line.Begin : line.End;
        }

        private void SetItemsState(bool state)
        {
            choosingLineComboBox.Enabled = state;
            changingButton.Enabled = state;
            firstEndButton.Enabled = state;
            secondEndButton.Enabled = state;
        }

        private void UndoButtonClick(object sender, EventArgs e)
        {
            if (!stateManager.IsStatesEmpty())
            {
                stateManager.Undo();
                RedoButton.Enabled = true;
                if (stateManager.IsStatesEmpty())
                    undoButton.Enabled = false;
                ComboBoxChanging();
            }
            else
            {
                stateManager = new StateManager();
                undoButton.Enabled = false;
            }
        }

        private void RedoButtonClick(object sender, EventArgs e)
        {
            stateManager.Redo();
            undoButton.Enabled = true;
            ComboBoxChanging();
            if (stateManager.IsRedoEmpty())
                RedoButton.Enabled = false;
        }

        private void ComboBoxChanging()
        {
            choosingLineComboBox.Items.Clear();
            for (int i = 1; i <= stateManager.GetCurrentState().Count; ++i)
            {
                choosingLineComboBox.Items.Add("Линия" + i);
            }
        }
    }
}