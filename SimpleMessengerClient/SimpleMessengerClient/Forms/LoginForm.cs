using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleMessenger
{
    public partial class LoginForm : Form
    {
        public int i = 0;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var a = new System.Windows.Forms.PictureBox();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void ASD(object sender, EventArgs e)
        {

            Thread t = new Thread(TestThread);
            t.Start();
        }

        private void TestThread()
        {
            i++;
            textBox1.Text = i.ToString();
        }
    }
}
