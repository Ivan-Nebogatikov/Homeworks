using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            if ((buttons[0].Content.ToString() == buttons[1].Content.ToString() && buttons[0].Content.ToString() == buttons[2].Content.ToString() && buttons[0].Content.ToString() == character)
                || (buttons[0].Content.ToString() == buttons[4].Content.ToString() && buttons[0].Content.ToString() == buttons[8].Content.ToString() && buttons[0].Content.ToString() == character)
                || (buttons[0].Content.ToString() == buttons[3].Content.ToString() && buttons[0].Content.ToString() == buttons[6].Content.ToString() && buttons[0].Content.ToString() == character)
                || (buttons[3].Content.ToString() == buttons[4].Content.ToString() && buttons[3].Content.ToString() == buttons[5].Content.ToString() && buttons[3].Content.ToString() == character)
                || (buttons[6].Content.ToString() == buttons[7].Content.ToString() && buttons[6].Content.ToString() == buttons[8].Content.ToString() && buttons[6].Content.ToString() == character)
                || (buttons[1].Content.ToString() == buttons[4].Content.ToString() && buttons[1].Content.ToString() == buttons[7].Content.ToString() && buttons[1].Content.ToString() == character)
                || (buttons[2].Content.ToString() == buttons[5].Content.ToString() && buttons[2].Content.ToString() == buttons[8].Content.ToString() && buttons[2].Content.ToString() == character)
                || (buttons[2].Content.ToString() == buttons[4].Content.ToString() && buttons[2].Content.ToString() == buttons[6].Content.ToString() && buttons[2].Content.ToString() == character))
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
