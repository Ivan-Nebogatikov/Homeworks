using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace _1
{
    /// <summary>
    /// Main program class
    /// </summary>
    public partial class MainPage : UserControl
    {
        private readonly Button[] buttons;

        /// <summary>
        /// Initialization method
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            buttons = new Button[9];
            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            buttons[4] = button5;
            buttons[5] = button6;
            buttons[6] = button7;
            buttons[7] = button8;
            buttons[8] = button9;
        }

        private void RefreshButtonClick(object sender, RoutedEventArgs e)
        {
            foreach (var button in buttons)
            {
                button.Content = "";
            }
            resultLabel.Content = "";
        }

        private void CheckWin(string character)
        {
            System.Func<int, string> label = x => buttons[x].Content.ToString();
            if ((label(0) == label(1) && label(1) == label(2) && label(0) == character)
                || (label(0) == label(4) && label(0) == label(8) && label(0) == character)
                || (label(0) == label(3) && label(0) == label(6) && label(0) == character)
                || (label(3) == label(4) && label(3) == label(5) && label(3) == character)
                || (label(6) == label(7) && label(6) == label(8) && label(6) == character)
                || (label(1) == label(4) && label(1) == label(7) && label(1) == character)
                || (label(2) == label(5) && label(2) == label(8) && label(2) == character)
                || (label(2) == label(4) && label(2) == label(6) && label(2) == character))
            {
                resultLabel.Content = character.ToUpper() + " win";
            }
        }

        private void ComputerMove()
        {
            foreach (var button in buttons.Where(x => x.Content.ToString().Length == 0))
            {
                button.Content = "0";
                CheckWin("0");
                return;
            }
        }

        private void PlayButtonClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if (resultLabel.Content.ToString().Length == 0 && button.Content.ToString().Length == 0)
            {
                button.Content = "x";
                CheckWin("x");
                ComputerMove();
            }
        }
    }
}
