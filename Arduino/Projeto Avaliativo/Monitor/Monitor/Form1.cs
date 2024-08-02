using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor
{
    public partial class Form1 : Form
    {
        MonitorSerial monitor = new MonitorSerial();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(progressBar1.Step); 
            label1.Text = progressBar1.Value.ToString() + "%";
            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                this.Hide();
                monitor.ShowDialog();
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
