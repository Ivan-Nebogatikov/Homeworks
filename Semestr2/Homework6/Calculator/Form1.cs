using System;
using System.Windows.Forms;

namespace Calculator
{
    /// <summary>
    /// Class for main program form
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnNumberButtonPressed(object sender, EventArgs e)
        {
            var temp = (Button)sender;
            inputLabel.Text += temp.Text;
        }

        private void OnOperationButtonPressed(object sender, EventArgs e)
        {
            if (resultLabel.Text.Length == 0 || resultLabel.Text == @"Division by zero")
                resultLabel.Text = @"0";
            Calctulate(sender, e);
            inputLabel.Text = "";
            signLabel.Text = ((Button)sender).Text;
        }

        private void Calctulate(object sender, EventArgs e)
        {
            if (inputLabel.Text.Length == 0)
                return;
            switch (signLabel.Text)
            {
                case "+":
                    resultLabel.Text = (Convert.ToInt32(resultLabel.Text) + Convert.ToInt32(inputLabel.Text)).ToString();
                    break;
                case "-":
                    resultLabel.Text = (Convert.ToInt32(resultLabel.Text) - Convert.ToInt32(inputLabel.Text)).ToString();
                    break;
                case "*":
                    resultLabel.Text = (Convert.ToInt32(resultLabel.Text) * Convert.ToInt32(inputLabel.Text)).ToString();
                    break;
                case "/":
                    if (Convert.ToInt32(inputLabel.Text) == 0)
                        resultLabel.Text = @"Division by zero";
                    else
                        resultLabel.Text = (Convert.ToInt32(resultLabel.Text) / Convert.ToInt32(inputLabel.Text)).ToString();
                    break;
            }
            inputLabel.Text = "";
            signLabel.Text = "";
        }

        private void OnCleanButtonPressed(object sender, EventArgs e)
        {
            inputLabel.Text = "";
            signLabel.Text = "";
            resultLabel.Text = "";
        }
    }
}
