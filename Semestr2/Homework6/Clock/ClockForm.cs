using System;
using System.Drawing;
using System.Windows.Forms;

namespace Clock
{
    /// <summary>
    /// Main program form
    /// </summary>
    public partial class Clock : Form
    {
        private int prevWidth;
        private int prevHeight;
        private const float scale = 2 / 5f;
        /// <summary>
        /// Form constructor
        /// </summary>
        public Clock()
        {
            InitializeComponent();
            hours.Text = DateTime.Now.Hour.ToString().PadLeft(2, '0');
            minutes.Text = DateTime.Now.Minute.ToString().PadLeft(2, '0');
            prevHeight = Height;
            prevWidth = Width;
            ClockResize(null, null);
        }

        private void OnClockTimerTick(object sender, EventArgs e)
        {

            hours.Text = DateTime.Now.Hour.ToString().PadLeft(2, '0');
            minutes.Text = DateTime.Now.Minute.ToString().PadLeft(2, '0');
            colon.Visible = !colon.Visible;
        }

        private void ClockResize(object sender, EventArgs e)
        {
            var font = new Font(hours.Font.FontFamily, Math.Min(hours.Height * scale, hours.Width * scale));
            hours.Font = font;
            minutes.Font = font;
            colon.Font = font;
            prevWidth = Width;
            prevHeight = Height;
        }
    }
}
