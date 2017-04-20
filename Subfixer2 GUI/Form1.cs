using System;
using System.Windows.Forms;
using Subfixer2_libs;
using System.Collections.Generic;

namespace Subfixer2_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] files = textBox1.Text.Split(';');
            string[] typs = textBox2.Text.Split(';');
            ShowError se = mbox;
            libs.head(se, checkBox1.Checked, new List<string>(typs), files);

        }
        public void mbox(string text)
        {
            MessageBox.Show(text);
        }
    }
}
