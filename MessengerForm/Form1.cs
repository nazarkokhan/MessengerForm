using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessengerForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Pipe_Load(object sender, EventArgs e)
        {
  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newMassage = textBox1.Text;

            if (string.IsNullOrEmpty(newMassage))
            {
                return;
            }

            listBox1.Items.Add(newMassage);

            textBox1.Text = string.Empty;
        }
    }
}