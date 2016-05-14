using System;
using System.Reflection;
using System.Windows.Forms;

namespace Problem2
{
    /// <summary>
    /// Main form class
    /// </summary>
    public partial class AssemblyViewer : Form
    {
        /// <summary>
        /// Form consructor
        /// </summary>
        public AssemblyViewer()
        {
            InitializeComponent();
        }

        private void FindButtonClick(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = @"dll files (*.dll)||exe files (*.exe)|",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pathLabel.Text = openFileDialog1.FileName;
                    var sampleAssembly = Assembly.LoadFile(openFileDialog1.FileName);
                    classTextBox.Text = "";
                    foreach (var type in sampleAssembly.GetTypes())
                    {
                        classTextBox.Text += type.FullName + "\r\n";
                        foreach (var m in type.GetMethods())
                        {
                            classTextBox.Text += @" --> " + m.ReturnType.Name + @"   " + m.Name + @"(";
                            var p = m.GetParameters();
                            for (var i = 0; i < p.Length; i++)
                            {
                                classTextBox.Text += p[i].ParameterType.Name + @" " + p[i].Name;
                                if (i + 1 < p.Length) classTextBox.Text += @", ";
                            }
                            classTextBox.Text += ")\r\n";
                        }
                        classTextBox.Text += "\r\n";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
