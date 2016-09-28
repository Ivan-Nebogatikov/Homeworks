using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Homework4
{
    public partial class mainForm : Form
    {
        private readonly Pen pen = new Pen(Color.Black, 2);
        private readonly Graphics graphics;
        private bool isDrawing;
        private Point firstCoordinate;
        private List<Tuple<Point, Point>> lines = new List<Tuple<Point, Point>>();
        private readonly Stack<List<Tuple<Point, Point>>> states = new Stack<List<Tuple<Point, Point>>>();
        private readonly Stack<List<Tuple<Point, Point>>> redo = new Stack<List<Tuple<Point, Point>>>();

        public mainForm()
        {
            InitializeComponent();
            graphics = canvas.CreateGraphics();
            states.Push(new List<Tuple<Point, Point>>()); // Intitial state
        }

        private void CanvasPaint(object sender, PaintEventArgs e)
        {
            canvas.Refresh();
            var currentPoint = PointToClient(Cursor.Position);
            currentPoint.X -= canvas.Left;
            currentPoint.Y -= canvas.Top;
            if (isDrawing)
                graphics.DrawLine(pen, firstCoordinate.X, firstCoordinate.Y,
                    currentPoint.X, currentPoint.Y);
            foreach (var line in lines)
            {
                graphics.DrawLine(pen, line.Item1.X, line.Item1.Y, line.Item2.X, line.Item2.Y);
            }
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
                lines.Add(new Tuple<Point, Point>(firstCoordinate, secondCoordinate));
                choosingLineComboBox.Items.Add("Линия " + (choosingLineComboBox.Items.Count + 1));
                states.Push(lines.ToList());
                undoButton.Enabled = true;
                RedoButton.Enabled = false;
                redo.Clear();
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
            var ne = lines[choosingLineComboBox.SelectedIndex];
            lines.RemoveAt(choosingLineComboBox.SelectedIndex);
            choosingLineComboBox.Items.RemoveAt(choosingLineComboBox.Items.Count - 1);
            SetItemsState(false);
            firstCoordinate = firstEndButton.Checked ? ne.Item1 : ne.Item2;
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
            if (states.Count > 1)
            {
                var temp = states.Pop();
                redo.Push(temp);
                RedoButton.Enabled = true;
                temp = states.Pop();
                lines = temp;
                states.Push(temp.ToList());
                if (states.Count <= 1)
                    undoButton.Enabled = false;
                ComboBoxChanging();
            }
            else
            {
                lines.Clear();
                undoButton.Enabled = false;
            }
        }

        private void RedoButtonClick(object sender, EventArgs e)
        {
            var temp = redo.Pop();
            states.Push(temp.ToList());
            lines = temp;
            undoButton.Enabled = true;
            ComboBoxChanging();
            if (redo.Count == 0)
                RedoButton.Enabled = false;
        }

        private void ComboBoxChanging()
        {
            choosingLineComboBox.Items.Clear();
            for (int i = 1; i <= lines.Count; ++i)
            {
                choosingLineComboBox.Items.Add("Линия" + i);
            }
        }
    }
}